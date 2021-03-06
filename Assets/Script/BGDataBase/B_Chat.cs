using System;
using System.Collections.Generic;
using UnityEngine;
using BansheeGz.BGDatabase;

//=============================================================
//||                   Generated by BansheeGz Code Generator ||
//=============================================================

[AddComponentMenu("BansheeGz/Generated/B_Chat")]
public partial class B_Chat : BGEntityGo
{
	public override BGMetaEntity MetaConstraint
	{
		get
		{
			return MetaDefault;
		}
	}
	private static BansheeGz.BGDatabase.BGMetaRow _metaDefault;
	public static BansheeGz.BGDatabase.BGMetaRow MetaDefault
	{
		get
		{
			if(_metaDefault==null || _metaDefault.IsDeleted) _metaDefault=BGRepo.I.GetMeta<BansheeGz.BGDatabase.BGMetaRow>(new BGId(5546031450402290947,16712102860754600867));
			return _metaDefault;
		}
	}
	public static BansheeGz.BGDatabase.BGRepoEvents Events
	{
		get
		{
			return BGRepo.I.Events;
		}
	}
	public new System.String name
	{
		get
		{
			return _name[Entity.Index];
		}
		set
		{
			_name[Entity.Index] = value;
		}
	}
	public System.Int32 ObjNum
	{
		get
		{
			return _ObjNum[Entity.Index];
		}
		set
		{
			_ObjNum[Entity.Index] = value;
		}
	}
	public System.String ChatString
	{
		get
		{
			return _ChatString[Entity.Index];
		}
		set
		{
			_ChatString[Entity.Index] = value;
		}
	}
	public System.Int32 ChatNum
	{
		get
		{
			return _ChatNum[Entity.Index];
		}
		set
		{
			_ChatNum[Entity.Index] = value;
		}
	}
	private static BansheeGz.BGDatabase.BGFieldEntityName __name;
	public static BansheeGz.BGDatabase.BGFieldEntityName _name
	{
		get
		{
			if(__name==null || __name.IsDeleted) __name=(BansheeGz.BGDatabase.BGFieldEntityName) MetaDefault.GetField(new BGId(5614771609181471789,12546016194889850768));
			return __name;
		}
	}
	private static BansheeGz.BGDatabase.BGFieldInt __ObjNum;
	public static BansheeGz.BGDatabase.BGFieldInt _ObjNum
	{
		get
		{
			if(__ObjNum==null || __ObjNum.IsDeleted) __ObjNum=(BansheeGz.BGDatabase.BGFieldInt) MetaDefault.GetField(new BGId(4865286558714921774,5117919433651875226));
			return __ObjNum;
		}
	}
	private static BansheeGz.BGDatabase.BGFieldString __ChatString;
	public static BansheeGz.BGDatabase.BGFieldString _ChatString
	{
		get
		{
			if(__ChatString==null || __ChatString.IsDeleted) __ChatString=(BansheeGz.BGDatabase.BGFieldString) MetaDefault.GetField(new BGId(5192925461702966739,13607613804958907285));
			return __ChatString;
		}
	}
	private static BansheeGz.BGDatabase.BGFieldInt __ChatNum;
	public static BansheeGz.BGDatabase.BGFieldInt _ChatNum
	{
		get
		{
			if(__ChatNum==null || __ChatNum.IsDeleted) __ChatNum=(BansheeGz.BGDatabase.BGFieldInt) MetaDefault.GetField(new BGId(5440242012601217819,549540831188726684));
			return __ChatNum;
		}
	}
}
