# Chat Server and Client program set.

## There is a client and a server.</br>

The server accesses MY WEB SITE to get its IP.</br>
I included the PHP scripts if you want to put these on your site.
You will need to change the line in the code that points at tnmshouse.com to match your site and path to where these 2 scripts are located on your web site.</br>
Put the two scripts on your site and change the ip in getserverip.php to point at your server where the chat server is located</br></br>
The getip.php script returns the WAN ip address to the chat client and is used to sign in to the server. It is NOT the local router IP. DO NOT EDIT THAT SCRIPT!</br>


I added a checkBox to auto login to the server.</br>
You must log in at least once so that the username is set.</br>
To shut of auto login, Log out and uncheck Auto Connect.