cd /usr/jexus/siteconf
echo >fgcjfg
echo "hosts=whuanle.cn"
echo "ports=80"
echo "root=/ /a"
echo "AppHost={"
echo "CmdLine=dotnet /a;"
echo "AppRoot=/a;"
echo "port=45;"
echo "}"
echo "nolog=false"
cd /usr/jexus
./jws strat fgcjfg
