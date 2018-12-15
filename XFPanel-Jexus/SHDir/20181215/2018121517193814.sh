cd /usr/jexus/siteconf
echo >xjexus
echo "hosts=test666.whuanle.cn"
echo "ports=80"
echo "root=/ /var"
echo "AppHost={"
echo "CmdLine=dotnet /var/a/dll;"
echo "AppRoot=/var;"
echo "port=12546;"
echo "}"
echo "nolog=false"
cd /usr/jexus
./jws strat xjexus
