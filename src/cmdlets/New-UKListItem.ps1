function New-UKListItem {
    [CmdletBinding()]
    Param (
        [Parameter(Mandatory=$False,Position=0)]
        [string]$Label,
        
        [Parameter(Mandatory=$False,Position=2)]
        [array]$Link,
        
        [Parameter(Mandatory=$False)]
        [switch]$Header,
        
        [Parameter(Mandatory=$False)]
        [switch]$Divider,
        
        [Parameter(Mandatory=$False)]
        [switch]$AsHtml = $true,
        
        [Parameter(Mandatory=$False)]
        [switch]$AsObject
    )

    $ReturnObject       = New-Object PoshUIKit.ListItem
    $ReturnObject.Label = $Label
    $ReturnObject.Link  = $Link
    
    if ($Header)  { $ReturnObject.IsHeader  = $true }
    if ($Divider) { $ReturnObject.IsDivider = $true }

    
    if ($AsObject) { return $ReturnObject }
    if ($AsHtml) { return $ReturnObject.Html() }
}