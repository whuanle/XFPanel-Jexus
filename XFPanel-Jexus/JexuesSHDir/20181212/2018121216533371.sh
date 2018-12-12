cd /usr/jexus/siteconf
echo >78987
echo "ports=0"
echo "root=/ "
echo "AppHost={"
echo "CmdLine=dotnet ;"
echo "AppRoot=;"
echo "port=0;"
echo "}"
echo "nolog=false"
cd /usr/jexus
./jws strat 78987
