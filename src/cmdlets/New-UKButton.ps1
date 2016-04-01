function New-UKButton {
    [CmdletBinding()]
    Param (
        [Parameter(Mandatory=$False,Position=0)]
        [string]$Label,
        
        [Parameter(Mandatory=$False,Position=1)]
        [string]$Link,
        
        [Parameter(Mandatory=$False,Position=2)]
        [array]$Classes,
        
        [Parameter(Mandatory=$False)]
        [switch]$AsHtml = $true,
        
        [Parameter(Mandatory=$False)]
        [switch]$AsObject
    )

    $ReturnObject           = New-Object PoshUIKit.Button
    $ReturnObject.Label     = $Label
    $ReturnObject.Link      = $Link
    $ReturnObject.UKClasses = $Classes
    
    $global:test = $ReturnObject
    
    if ($AsObject) { return $ReturnObject }
    if ($AsHtml) { return $ReturnObject.Html() }
}