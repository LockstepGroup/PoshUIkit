###############################################################################
## Start Powershell Cmdlets
###############################################################################

###############################################################################
# New-UKBreadcrumbs

function New-UKBreadcrumbs {
    [CmdletBinding()]

    Param (
        [Parameter(Mandatory=$True,Position=0)]
        [String]$CurrentPath,
        
        [Parameter(Mandatory=$True,Position=1)]
        [String]$ExcludePath
    )
    
    $HtmlOutput  = '<div class="uk-grid" data-uk-grid-margin>'
    $HtmlOutput += '<div class="uk-width-1-1">'
    $HtmlOutput += '<ul class="uk-breadcrumb">'
    
    if ($ExcludePath[-1] -ne '\') { $ExcludePath += '\' }
    $FullPathSplit = $CurrentPath -replace [Regex]::Escape($ExcludePath),""
    $FullPathSplit = $FullPathSplit.Split('\')
    
    $i = 0
    foreach ($Split in $FullPathSplit) {
        $i++
        if ($Split -eq $FullPathSplit[-1]) {
            $HtmlOutput += '<li class="uk-active"><span>' + $Split + '</span></li>' + "`r`n"
        } else {
            $Dots = ""
            if (($FullPathSplit.Count - $i) -eq 1) {
                $Dots = './'
            } else {
                for ($d = 2;$d -le ($FullPathSplit.Count - $i);$d++) {

                    $Dots += '../'
                }
            }
            $HtmlOutput += '<li><a href="' + $Dots + '">' + $Split + '</a></li>' + "`r`n"
        }
    }
    $HtmlOutput += "</ul></div></div>"

    return $HtmlOutput
}

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
    if ($Classes) { $ReturnObject.UKClasses = $Classes }
    
    if ($AsObject) { return $ReturnObject }
    if ($AsHtml) { return $ReturnObject.Html() }
}

###############################################################################
# New-UKButtonGroup

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
    if ($Classes) { $ReturnObject.UKClasses = $Classes }

    if ($AsObject) { return $ReturnObject }
    if ($AsHtml) { return $ReturnObject.Html() }
}

###############################################################################
# New-UKDropdown

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
    if ($Classes) { $ReturnObject.UKClasses = $Classes } 
    $ReturnObject.Mode      = $Mode
    
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
        [array]$Classes,
        
        [Parameter(Mandatory=$False)]
        [switch]$AsHtml = $true,
        
        [Parameter(Mandatory=$False)]
        [switch]$AsObject
    )

    $ReturnObject      = New-Object PoshUIKit.Icon
    $ReturnObject.Name = "uk-icon-" + $Name.ToLower()
    
    if ($Size) { $ReturnObject.Size = "uk-icon-" + $Size.ToLower() }
    if ($Span) { $ReturnObject.Type = "span" }
    
    if ($Classes) { $ReturnObject.UKClasses = $Classes }
    
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
    if ($Classes) { $ReturnObject.UKClasses = $Classes } 
    
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
