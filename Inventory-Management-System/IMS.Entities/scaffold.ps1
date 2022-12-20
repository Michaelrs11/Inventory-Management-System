$connectionString = "Server=.;Database=Inventory_Management_System;Trusted_Connection=True;";
$provider = "Microsoft.EntityFrameworkCore.SqlServer";
$dbContextName = "IMSDBContext";

Remove-Item *.cs;

$tableListBuilder = [System.Text.StringBuilder]::new();

# Reference: https://powershellexplained.com/2017-11-20-Powershell-StringBuilder/
foreach ($table in Get-Content .\Migrations\TableList.txt) {
    [void]$tableListBuilder.Append("-t $table ");
}

# -c: set DB Context name to...
# -d: use Data Annotation / attributes where possible.
# --use-database-names: do not PascalCase-ify table and column names.
# -v: show verbose output.
$command = "dotnet ef dbcontext scaffold ""$ConnectionString"" $provider -c $dbContextName -d --use-database-names -v "
$concatenatedTableName = $tableListBuilder.ToString();

Invoke-Expression "$command $concatenatedTableName";


dotnet ef dbcontext scaffold $ConnectionString $provider -c $dbContextName -d --use-database-names -v