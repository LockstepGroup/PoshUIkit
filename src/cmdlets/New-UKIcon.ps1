function New-UKIcon {
    [CmdletBinding()]
    Param (
        [Parameter(Mandatory=$True,Position=0)]
        [string]$Name,
        
        [Parameter(Mandatory=$False,Position=2)]
        [ValidateSet("small","medium","large")]
        [array]$Size,
        
        [Parameter(Mandatory=$False)]
        [switch]$Span,
        
        [Parameter(Mandatory=$False)]
        [switch]$AsHtml = $true,
        
        [Parameter(Mandatory=$False)]
        [switch]$AsObject
    )

    $ReturnObject                   = New-Object PoshUIKit.Icon
    $ReturnObject.Name              = "uk-icon-" + $Name.ToLower()
    if ($Size) { $ReturnObject.Size = "uk-icon-" + $Size.ToLower() }
    if ($Span) { $ReturnObject.Type = "span" }
    
    if ($AsObject) { return $ReturnObject }
    if ($AsHtml) { return $ReturnObject.Html() }
}