cd /usr/jexus/siteconf
echo >fr
echo "hosts=io"
echo "ports=80"
echo "root=/ /gh"
echo "AppHost={"
echo "CmdLine=dotnet /fg;"
echo "AppRoot=/gh;"
echo "port=874;"
echo "}"
echo "nolog=false"
cd /usr/jexus
./jws strat fr
