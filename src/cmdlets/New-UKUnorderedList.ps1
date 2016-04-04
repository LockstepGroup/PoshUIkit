function New-UKUnorderedList {
    [CmdletBinding()]
    Param (
        [Parameter(Mandatory=$True,Position=0)]
        [array]$ListItems,
        
        [Parameter(Mandatory=$False,Position=1)]
        [array]$Classes,
        
        [Parameter(Mandatory=$False)]
        [switch]$AsHtml = $true,
        
        [Parameter(Mandatory=$False)]
        [switch]$AsObject
    )

    $ReturnObject           = New-Object PoshUIKit.UnorderedList
    $ReturnObject.ListItems = $ListItems
    if ($Classes) { $ReturnObject.UKClasses = $Classes } 
    
    if ($AsObject) { return $ReturnObject }
    if ($AsHtml) { return $ReturnObject.Html() }
}