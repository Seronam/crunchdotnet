Add-Type -Path "$PSScriptRoot\Crunch.DotNet.dll"

$consumerKey = Read-Host -Prompt "Please enter consumer key"
$consumerSecret = Read-Host -Prompt "Please enter consumer secret"

$urls = New-Object Crunch.DotNet.Authorization.CrunchRestUrlProvider([Crunch.DotNet.CrunchEnvironment]::Demo)
$oauthWorkflow = New-Object Crunch.DotNet.Authorization.OAuthWorkflow($consumerKey, $consumerSecret, $urls)

$tempTokens = $oauthWorkflow.InitiateAccessRequest()

$verificationUrl = $urls.GetAuthLogin($tempTokens.TemporaryToken)

$verificationUrl
start $verificationUrl

$verificationToken = Read-Host -Prompt "Please enter verification key"

$tokens = $oauthWorkflow.RequestAccess($verificationToken, $tempTokens)

ConvertTo-Json $tokens | Out-File -FilePath "$PSScriptRoot\tokens.json"
