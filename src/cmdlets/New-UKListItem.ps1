function New-UKListItem {
    [CmdletBinding()]
    Param (
        [Parameter(Mandatory=$False,Position=0)]
        [string]$Label,
        
        [Parameter(Mandatory=$False,Position=2)]
        [array]$Link,
        
        [Parameter(Mandatory=$False,ParameterSetName="headerobject")]
        [Parameter(ParameterSetName="headerhtml")]
        [switch]$Header,
        
        [Parameter(Mandatory=$False,ParameterSetName="dividerobject")]
        [Parameter(ParameterSetName="dividerhtml")]
        [switch]$Divider,
        
        [Parameter(Mandatory=$False,ParameterSetName="headerhtml")]
        [Parameter(ParameterSetName="dividerhtml")]
        [switch]$AsHtml = $true,
        
        [Parameter(Mandatory=$False,ParameterSetName="headerobject")]
        [Parameter(ParameterSetName="dividerobject")]
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