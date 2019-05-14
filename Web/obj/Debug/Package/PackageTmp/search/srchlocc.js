function GetTodayDate()
{
	var retVal, tgl = new Date();
	var d,m,y;
	
	d = tgl.getDate();
	m = tgl.getMonth()+1;
	y = tgl.getFullYear();
	
	if (d<10)
	{
		d='0'+d;
	}
	if (m<10)
	{
		m='0'+m
	}
	
	retVal = d+'-'+m+'-'+y+'*';//tgl.getDay()+'-'+tgl.getMonth()+'-'+tgl.getFullYear();
	return retVal;
}