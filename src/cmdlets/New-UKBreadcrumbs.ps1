function New-UKBreadcrumbs {
    [CmdletBinding()]

    Param (
        [Parameter(Mandatory=$True,Position=0)]
        [String]$CurrentPath,
        
        [Parameter(Mandatory=$True,Position=1)]
        [String]$ExcludePath
    )
    
    $HtmlOutput = @"
<div class="uk-grid" data-uk-grid-margin>
    <div class="uk-width-1-1">
        <ul class="uk-breadcrumb">
"@
    
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
    $HtmlOutput += @"
        </ul>
    </div>
</div>
"@