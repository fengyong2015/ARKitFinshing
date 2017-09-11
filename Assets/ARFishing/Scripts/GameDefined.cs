public enum FishType
{
	None = 0,
	///扯旗鱼
	cheqiyu = 1,
	///灯笼鱼
	denglongyu = 2,
	///电鳗鱼
	dianmanyu = 3,
	///帝鲶鱼
	dinianyu = 4,
	///鲂鱼
	fangyu = 5,
	///海龟
	haigui = 6,
	///河豚 
	hetun = 7,
	///剑鱼 
	jianyu = 8,
	///金枪鱼 
	jinqiangyu = 9,
	///鲨鱼 
	shayu = 10,
	///狮子鱼
	shiziyu = 11,
	///天使鱼 
	tianshiyu = 12,
	///小丑鱼
	xiaochouyu = 13,
	///小黄鱼
	xiaohuangyu = 14,
}


public static class FishTypeExtensions
{
	public static string FishInfo (this FishType pFishType)
	{
		string tInfo = string.Empty;
		switch (pFishType) {
		case FishType.cheqiyu:
			tInfo = "扯旗鱼属于脂鲤科小型热带鱼，体型侧扁，尾鳍呈叉型，雄鱼的背鳍高耸飘逸，犹如一面迎风招展的旗帜，因而得名";
			break;
		case FishType.denglongyu:
			tInfo = "灯笼鱼头大尾细，身体圆尾巴细，体表被有银灰色的薄鳞。在头部的前边，眼的附近，身体侧线下方和尾柄上，有排列成行或成群的圆形发光器。";
			break;
		case FishType.dianmanyu:
			tInfo = "";
			break;
		case FishType.dinianyu:
			tInfo = "";
			break;
		case FishType.fangyu:
			tInfo = "";
			break;
		case FishType.haigui:
			tInfo = "";
			break;
		case FishType.hetun:
			tInfo = "";
			break;
		case FishType.jianyu:
			tInfo = "";
			break;
		case FishType.jinqiangyu:
			tInfo = "";
			break;
		case FishType.shayu:
			tInfo = "";
			break;
		case FishType.shiziyu:
			tInfo = "";
			break;
		case FishType.tianshiyu:
			tInfo = "";
			break;
		case FishType.xiaochouyu:
			tInfo = "";
			break;
		case FishType.xiaohuangyu:
			tInfo = "";
			break;
		}
		return tInfo;
	}

	public static string FishName (this FishType pFishType)
	{
		string tInfo = string.Empty;
		switch (pFishType) {
		case FishType.cheqiyu:
			tInfo = "扯旗鱼";
			break;
		case FishType.denglongyu:
			tInfo = "灯笼鱼";
			break;
		case FishType.dianmanyu:
			tInfo = "电鳗";
			break;
		case FishType.dinianyu:
			tInfo = "帝鲶鱼";
			break;
		case FishType.fangyu:
			tInfo = "鲂鱼";
			break;
		case FishType.haigui:
			tInfo = "海龟";
			break;
		case FishType.hetun:
			tInfo = "河豚";
			break;
		case FishType.jianyu:
			tInfo = "剑鱼";
			break;
		case FishType.jinqiangyu:
			tInfo = "金枪鱼";
			break;
		case FishType.shayu:
			tInfo = "鲨鱼";
			break;
		case FishType.shiziyu:
			tInfo = "狮子鱼";
			break;
		case FishType.tianshiyu:
			tInfo = "天使鱼";
			break;
		case FishType.xiaochouyu:
			tInfo = "小丑鱼";
			break;
		case FishType.xiaohuangyu:
			tInfo = "小黄鱼";
			break;
		}
		return tInfo;
	}
}
