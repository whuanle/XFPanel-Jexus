cd /usr/jexus/siteconf
echo >afe
echo "hosts=ertes"
echo "ports=0"
echo "root=/ "
echo "AppHost={"
echo "CmdLine=dotnet ;"
echo "AppRoot=;"
echo "port=0;"
echo "}"
echo "nolog=false"
cd /usr/jexus
./jws strat afe
