function New-UKButton {
    [CmdletBinding()]
    Param (
        [Parameter(Mandatory=$False,Position=0)]
        [string]$Name,
        
        [Parameter(Mandatory=$False,Position=1)]
        [string]$Link,
        
        [Parameter(Mandatory=$False,Position=2)]
        [array]$Classes,
        
        [Parameter(Mandatory=$False)]
        [switch]$AsHtml = $true,
        
        [Parameter(Mandatory=$False)]
        [switch]$AsObject
    )

    $ReturnObject = New-Object PoshUIKit.Button
    $ReturnObject.Name = $Name
    $ReturnObject.Link = $Link
    $ReturnObject.UKClasses = $Classes
    
    if ($AsObject) { return $ReturnObject }
    if ($AsHtml) { return $ReturnObject.Html() }
}