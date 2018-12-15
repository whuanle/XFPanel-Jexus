cd /usr/jexus/siteconf
echo >szd
echo "hosts=eter"
echo "ports=80"
echo "root=/ /dr"
echo "AppHost={"
echo "CmdLine=dotnet /af;"
echo "AppRoot=/dr;"
echo "port=1234;"
echo "}"
echo "nolog=false"
cd /usr/jexus
./jws strat szd
