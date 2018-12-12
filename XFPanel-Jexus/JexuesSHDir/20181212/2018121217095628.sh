cd /usr/jexus/siteconf
echo >rtg
echo "hosts=setysd"
echo "ports=80"
echo "root=/ /afaf"
echo "AppHost={"
echo "CmdLine=dotnet ;"
echo "AppRoot=/afaf;"
echo "port=0;"
echo "}"
echo "nolog=false"
cd /usr/jexus
./jws strat rtg
