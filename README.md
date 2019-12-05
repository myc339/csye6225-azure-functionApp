get system key
<pre><code>
http://{functionappname}.azurewebsites.net/admin/host/systemkeys/eventgrid_extension?
code={masterkey}
</code></pre>

endpoint for event grid subscription
<pre><code>
https://{functionappname}.azurewebsites.net/runtime/webhooks/
eventgrid?functionName={functionname}&code={systemkey}
</code></pre>