function New-UKButtonGroup {
    [CmdletBinding()]
    Param (
        [Parameter(Mandatory=$False,ParameterSetName="buttons",Position=0)]
        [array]$Buttons,
        
        [Parameter(Mandatory=$False,ParameterSetName="dropdown",Position=0)]
        [PoshUIKit.Dropdown]$Dropdown,
        
        [Parameter(Mandatory=$False)]
        [switch]$AsHtml = $true,
        
        [Parameter(Mandatory=$False)]
        [switch]$AsObject
    )

    $ReturnObject = New-Object PoshUIKit.ButtonGroup

    if ($Buttons)  { $ReturnObject.Buttons  = $Buttons }
    if ($Dropdown) { $ReturnObject.Dropdown = $Dropdown }

    if ($AsObject) { return $ReturnObject }
    if ($AsHtml) { return $ReturnObject.Html() }
}