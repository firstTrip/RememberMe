using System;
using System.Collections.Generic;
using UnityEngine;
using BansheeGz.BGDatabase;

//=============================================================
//||                   Generated by BansheeGz Code Generator ||
//=============================================================

[AddComponentMenu("BansheeGz/Generated/B_Test")]
public partial class B_Test : BGEntityGo
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
			if(_metaDefault==null || _metaDefault.IsDeleted) _metaDefault=BGRepo.I.GetMeta<BansheeGz.BGDatabase.BGMetaRow>(new BGId(5424197432563735852,922744904582723006));
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
	public System.String Test
	{
		get
		{
			return _Test[Entity.Index];
		}
		set
		{
			_Test[Entity.Index] = value;
		}
	}
	private static BansheeGz.BGDatabase.BGFieldEntityName __name;
	public static BansheeGz.BGDatabase.BGFieldEntityName _name
	{
		get
		{
			if(__name==null || __name.IsDeleted) __name=(BansheeGz.BGDatabase.BGFieldEntityName) MetaDefault.GetField(new BGId(5678492040272658609,2048554231749686701));
			return __name;
		}
	}
	private static BansheeGz.BGDatabase.BGFieldText __Test;
	public static BansheeGz.BGDatabase.BGFieldText _Test
	{
		get
		{
			if(__Test==null || __Test.IsDeleted) __Test=(BansheeGz.BGDatabase.BGFieldText) MetaDefault.GetField(new BGId(5289459018999816265,13792968955359001519));
			return __Test;
		}
	}
}
