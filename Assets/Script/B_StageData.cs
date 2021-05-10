using System;
using System.Collections.Generic;
using UnityEngine;
using BansheeGz.BGDatabase;

//=============================================================
//||                   Generated by BansheeGz Code Generator ||
//=============================================================

[AddComponentMenu("BansheeGz/Generated/B_StageData")]
public partial class B_StageData : BGEntityGo
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
			if(_metaDefault==null || _metaDefault.IsDeleted) _metaDefault=BGRepo.I.GetMeta<BansheeGz.BGDatabase.BGMetaRow>(new BGId(4616669881433414317,999969829826134704));
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
	public UnityEngine.Vector3 ResponsePosition
	{
		get
		{
			return _ResponsePosition[Entity.Index];
		}
		set
		{
			_ResponsePosition[Entity.Index] = value;
		}
	}
	public UnityEngine.Quaternion ResponseRotation
	{
		get
		{
			return _ResponseRotation[Entity.Index];
		}
		set
		{
			_ResponseRotation[Entity.Index] = value;
		}
	}
	public System.Boolean StageClear
	{
		get
		{
			return _StageClear[Entity.Index];
		}
		set
		{
			_StageClear[Entity.Index] = value;
		}
	}
	private static BansheeGz.BGDatabase.BGFieldEntityName __name;
	public static BansheeGz.BGDatabase.BGFieldEntityName _name
	{
		get
		{
			if(__name==null || __name.IsDeleted) __name=(BansheeGz.BGDatabase.BGFieldEntityName) MetaDefault.GetField(new BGId(5319597434205999055,12568856221011576477));
			return __name;
		}
	}
	private static BansheeGz.BGDatabase.BGFieldVector3 __ResponsePosition;
	public static BansheeGz.BGDatabase.BGFieldVector3 _ResponsePosition
	{
		get
		{
			if(__ResponsePosition==null || __ResponsePosition.IsDeleted) __ResponsePosition=(BansheeGz.BGDatabase.BGFieldVector3) MetaDefault.GetField(new BGId(4778463960804466034,5786887131447245965));
			return __ResponsePosition;
		}
	}
	private static BansheeGz.BGDatabase.BGFieldQuaternion __ResponseRotation;
	public static BansheeGz.BGDatabase.BGFieldQuaternion _ResponseRotation
	{
		get
		{
			if(__ResponseRotation==null || __ResponseRotation.IsDeleted) __ResponseRotation=(BansheeGz.BGDatabase.BGFieldQuaternion) MetaDefault.GetField(new BGId(5079607956534320973,15847534016968931209));
			return __ResponseRotation;
		}
	}
	private static BansheeGz.BGDatabase.BGFieldBool __StageClear;
	public static BansheeGz.BGDatabase.BGFieldBool _StageClear
	{
		get
		{
			if(__StageClear==null || __StageClear.IsDeleted) __StageClear=(BansheeGz.BGDatabase.BGFieldBool) MetaDefault.GetField(new BGId(5024408334515454238,6020562075830421135));
			return __StageClear;
		}
	}
}
