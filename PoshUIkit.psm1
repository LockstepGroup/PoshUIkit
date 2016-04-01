###############################################################################
## Start Powershell Cmdlets
###############################################################################

###############################################################################
# New-UKButton

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
    
    if ($AsObject) { return $ReturnObject }
    if ($AsHtml) { return $ReturnObject.Html() }
}

###############################################################################
# New-UKIcon

function New-UKIcon {
    [CmdletBinding()]
    Param (
        [Parameter(Mandatory=$True,Position=0)]
        [string]$Name,
        
        [Parameter(Mandatory=$False,Position=2)]
        [ValidateSet("small","medium","large")]
        [string]$Size,
        
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

###############################################################################
# New-UKListItem

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

###############################################################################
# New-UKUnorderedList

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
    $ReturnObject.UKClasses = $Classes 
    
    if ($AsObject) { return $ReturnObject }
    if ($AsHtml) { return $ReturnObject.Html() }
}

###############################################################################
## Start Helper Functions
###############################################################################

###############################################################################
## Export Cmdlets
###############################################################################

Export-ModuleMember *-*
