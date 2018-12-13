cd /usr/jexus/siteconf
echo >
echo "ports=80"
echo "root=/ "
echo "AppHost={"
echo "CmdLine=dotnet ;"
echo "AppRoot=;"
echo "port=0;"
echo "}"
echo "nolog=false"
cd /usr/jexus
./jws strat 
