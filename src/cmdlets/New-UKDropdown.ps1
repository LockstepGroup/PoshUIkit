function New-UKDropdown {
    [CmdletBinding()]
    Param (
        [Parameter(Mandatory=$true,Position=0)]
        [PoshUIKit.Button]$Button,
        
        [Parameter(Mandatory=$true,Position=1)]
        [PoshUIKit.UnorderedList]$List,
        
        [Parameter(Mandatory=$False,Position=2)]
        [ValidateSet("hover","click")]
        [string]$Mode = "click",
        
        [Parameter(Mandatory=$False)]
        [array]$Classes,
        
        [Parameter(Mandatory=$False)]
        [switch]$AsHtml = $true,
        
        [Parameter(Mandatory=$False)]
        [switch]$AsObject
    )

    $ReturnObject           = New-Object PoshUIKit.Dropdown
    $ReturnObject.Button    = $Button
    $ReturnObject.List      = $List
    if ($UKClasses) { $ReturnObject.UKClasses = $Classes } 
    $ReturnObject.Mode      = $Mode
    
    if ($AsObject) { return $ReturnObject }
    if ($AsHtml) { return $ReturnObject.Html() }
}