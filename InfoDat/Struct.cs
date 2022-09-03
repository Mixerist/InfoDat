namespace InfoDat
{
    public class Struct
    {
        public DT_Item[] DT_Item { get; set; }
        public DT_ItemSkill[] DT_ItemSkill { get; set; }
        public DT_Monster[] DT_Monster { get; set; }
        public DT_ItemResource[] DT_ItemResource { get; set; }
        public DT_MonsterResource[] DT_MonsterResource { get; set; }
        public DT_SkillIgnoreCastingDelayGroup[] DT_SkillIgnoreCastingDelayGroup { get; set; }
        public DT_Skill[] DT_Skill { get; set; }
        public TP_AbnormalType[] TP_AbnormalType { get; set; }
        public DT_Abnormal[] DT_Abnormal { get; set; }
        public TblQuest[] TblQuest { get; set; }
        public TblQuestInfo[] TblQuestInfo { get; set; }
        public TblQuestCondition[] TblQuestCondition { get; set; }
        public TblQuestReward[] TblQuestReward { get; set; }
        public TblRegionQuest[] TblRegionQuest { get; set; }
        public TblRegionQuestCondition[] TblRegionQuestCondition { get; set; }
        public TP_SetItemInfo[] TP_SetItemInfo { get; set; }
        public TblSetItemMember[] TblSetItemMember { get; set; }
        public TP_SetItemEffectDesc[] TP_SetItemEffectDesc { get; set; }
        public TblMaterialItemInfo[] TblMaterialItemInfo { get; set; }
        public ChestDrop[] ChestDrop { get; set; }
        public TblItemIncSysPossibleItem[] TblItemIncSysPossibleItem { get; set; }
        public DT_RefineCreateInfo[] DT_RefineCreateInfo { get; set; }
        public DT_RefineMaterial[] DT_RefineMaterial { get; set; }
        public Zatochka[] Zatochka { get; set; }
        public DT_AchieveList[] DT_AchieveList { get; set; }
        public DT_AchieveItemCoin[] DT_AchieveItemCoin { get; set; }
        public DT_AchieveItemTrophy[] DT_AchieveItemTrophy { get; set; }
        public DT_AchieveGuildList[] DT_AchieveGuildList { get; set; }
        public TP_Servant[] TP_Servant { get; set; }
        public TblServantType[] TblServantType { get; set; }
        public TblServantCombineAddAbility[] TblServantCombineAddAbility { get; set; }
        public TblServantSkillTree[] TblServantSkillTree { get; set; }
        public TblServantEvolution[] TblServantEvolution { get; set; }
        public DT_SkillEnhancement[] DT_SkillEnhancement { get; set; }
        public DT_SkillEnhancementMaterial[] DT_SkillEnhancementMaterial { get; set; }
        public TblOtherMerchantInfo[] TblOtherMerchantInfo { get; set; }
        public TP_SkillTree[] TP_SkillTree { get; set; }
        public DT_SkillTreeNode[] DT_SkillTreeNode { get; set; }
        public DT_SkillTreeNodeItem[] DT_SkillTreeNodeItem { get; set; }
        public DT_SkillTreeNodeItemCondition[] DT_SkillTreeNodeItemCondition { get; set; }
        public DT_SkillPack[] DT_SkillPack { get; set; }
        public DT_SkillPackSkill[] DT_SkillPackSkill { get; set; }
    }

    public class DT_Item
    {
        public int IID { get; set; }
        public string IName { get; set; }
        public int IType { get; set; }
        public int IMaxStack { get; set; }
        public short IWeight { get; set; }
        public short ITermOfValidity { get; set; }
        public short ITermOfValidityMi { get; set; }
        public string IDesc { get; set; }
        public int IUseType { get; set; }
        public int IUseNum { get; set; }
        public short IStatus { get; set; }
        public int IFakeID { get; set; }
        public string IFakeName { get; set; }
        public string IUseMsg { get; set; }
        public short IRange { get; set; }
        public byte IUseClass { get; set; }
        public int IDropEffect { get; set; }
        public short IUseLevel { get; set; }
        public byte ILevel { get; set; }
        public short IUseEternal { get; set; }
        public int IUseDelay { get; set; }
        public short unknown1 { get; set; }
        public int unknown2 { get; set; }
        public int unknown3 { get; set; }
        public int unknown4 { get; set; }
        public byte IIsIndict { get; set; }
        public byte IIsCharge { get; set; }
        public byte IPShopItemType { get; set; }
        public long INationOp { get; set; }
        public byte IContentsLv { get; set; }
        public byte IIsSealable { get; set; }
        public byte mSealRemovalNeedCnt { get; set; }
        public byte unknown5 { get; set; }
        public byte mIsPracticalPeriod { get; set; }
        public short IAddShortAttackRange { get; set; }
        public short IAddLongAttackRange { get; set; }
        public short IGetItemFeedback { get; set; }
        public short ISubType { get; set; }
        public byte IMaxBeadHoleCount { get; set; }
    }

    public class DT_ItemSkill
    {
        public int IID { get; set; }
        public int SID { get; set; }
    }

    public class DT_Monster
    {
        public int MID { get; set; }
        public string MName { get; set; }
        public int MClass { get; set; }
        public short MGbjType { get; set; }
        public short MAiType { get; set; }
        public int mAttackRange { get; set; }
        public short MCastingDelay { get; set; }
        public float mScale { get; set; }
        public long mNationOp { get; set; }
        public byte IContentsLv { get; set; }
        public byte mIsShowHp { get; set; }
        public byte mSupportType { get; set; }
        public byte mWMapIconType { get; set; }
        public short mAttackType { get; set; }
        public short unknown1 { get; set; }
        public byte mIsEvent { get; set; }
        public short mEventQuest { get; set; }
        public float mEScale { get; set; }
    }

    public class DT_ItemResource
    {
        public int RID { get; set; }
        public int ROwnerID { get; set; }
        public int RType { get; set; }
        public string RFileName { get; set; }
        public int RPosX { get; set; }
        public int RPosY { get; set; }
    }

    public class DT_MonsterResource
    {
        public int RID { get; set; }
        public int ROwnerID { get; set; }
        public int RType { get; set; }
        public string RFileName { get; set; }
        public int RPosX { get; set; }
        public int RPosY { get; set; }
    }

    public class DT_SkillIgnoreCastingDelayGroup
    {
        public short SGroupNo { get; set; }
        public short SIgnoreGroup { get; set; }
    }

    public class DT_Skill
    {
        public int SID { get; set; }
        public string SName { get; set; }
        public short SMPPerUse { get; set; }
        public short SSpellNum { get; set; }
        public short SType { get; set; }
        public short SHPPerUse { get; set; }
        public short SChaoUse { get; set; }
        public short mApplyRace { get; set; }
        public short mCastingDelay { get; set; }
        public short mActiveType { get; set; }
        public string mAnimation { get; set; }
        public short mCastingSpeed { get; set; }
        public short mSkillEffect { get; set; }
        public int mCAmShakeWhenHit { get; set; }
        public short mCriticalEffectWhenHit { get; set; }
        public int mCoolTime { get; set; }
        public short mCastingGroup { get; set; }
        public short mCoolTimeGroup { get; set; }
        public int mConsumeItem { get; set; }
        public short mConsumeItemCnt { get; set; }
        public int mConsumeItem2 { get; set; }
        public short mConsumeItemCnt2 { get; set; }
        public byte mIsCancel { get; set; }
        public byte mIsAttack { get; set; }
    }

    public class TP_AbnormalType
    {
        public int AType { get; set; }
        public string AName { get; set; }
        public int AEffect { get; set; }
        public short ARemovable { get; set; }
        public string AFileName { get; set; }
        public short AIconX { get; set; }
        public short AIconY { get; set; }
    }

    public class DT_Abnormal
    {
        public int AID { get; set; }
        public byte ALevel { get; set; }
        public int AType { get; set; }
        public string ADesc { get; set; }
    }

    public class TblQuest
    {
        public int mQuestNo { get; set; }
        public byte mClass { get; set; }
        public int mLevel1 { get; set; }
        public int mLevel2 { get; set; }
        public int mPreQuestNo { get; set; }
        public byte mIsOverlap { get; set; }
        public int mMonsterID1 { get; set; }
        public int mMonsterID2 { get; set; }
        public int mMonsterID3 { get; set; }
        public int mMonsterID4 { get; set; }
        public int mMonsterID5 { get; set; }
        public int unknown1 { get; set; }
        public int unknown2 { get; set; }
        public int unknown3 { get; set; }
        public int mAbandonment { get; set; }
        public int mDifficulty { get; set; }
        public int mRewardNo { get; set; }
        public int mScriptType { get; set; }
        public int mPlace { get; set; }
        public float mPosX { get; set; }
        public float mPosY { get; set; }
        public float mPosZ { get; set; }
        public int mVisible { get; set; }
        public int mTextNo { get; set; }
        public int mParentNo { get; set; }
        public int mFindNPC { get; set; }
        public int mCompletionNPC { get; set; }
    }

    public class TblQuestInfo
    {
        public int mQuestNo { get; set; }
        public int mType { get; set; }
        public int mParmA { get; set; }
        public int mParmB { get; set; }
        public int mParmC { get; set; }
        public int mSeqNo { get; set; }
    }

    public class TblQuestCondition
    {
        public int mQuestNo { get; set; }
        public int mType { get; set; }
        public int mID { get; set; }
        public int mCnt { get; set; }
        public int mSeqNo { get; set; }
    }

    public class TblQuestReward
    {
        public int mRewardNo { get; set; }
        public long mExp { get; set; }
        public int mID { get; set; }
        public int mCnt { get; set; }
        public short mBinding { get; set; }
        public short mStatus { get; set; }
        public int mEffTime { get; set; }
        public int mValTime { get; set; }
    }

    public class TblRegionQuest
    {
        public int mQuestNo { get; set; }
        public string mQuestNmKey { get; set; }
    }

    public class TblRegionQuestCondition
    {
        public int mQuestNo { get; set; }
        public int mParmID { get; set; }
        public byte mBoss { get; set; }
        public byte mStepCnt { get; set; }
        public short mStep1 { get; set; }
        public short mStep2 { get; set; }
        public short mStep3 { get; set; }
        public short mTotalCnt { get; set; }
    }

    public class TP_SetItemInfo
    {
        public int mSetType { get; set; }
        public string mSetName { get; set; }
    }

    public class TblSetItemMember
    {
        public int mSetType { get; set; }
        public int IID { get; set; }
    }

    public class TP_SetItemEffectDesc
    {
        public int mSetType { get; set; }
        public string mDesc { get; set; }
    }

    public class TblMaterialItemInfo
    {
        public int IID { get; set; }
        public short MType { get; set; }
        public short MGrade { get; set; }
        public short MLevel { get; set; }
        public short MEnchant { get; set; }
    }

    public class ChestDrop
    {
        public int chest_id { get; set; }
        public int item_id { get; set; }
    }

    public class TblItemIncSysPossibleItem
    {
        public int mIID { get; set; }
        public byte mStatus { get; set; }
        public byte mCubeType { get; set; }
        public float mProb { get; set; }
        public int mResource { get; set; }
        public byte mKind { get; set; }
    }

    public class DT_RefineCreateInfo
    {
        public int mRID { get; set; }
        public int RItemID0 { get; set; }
        public byte mSort { get; set; }
        public int mCost { get; set; }
        public byte RSuccess { get; set; }
        public long mNationOp { get; set; }
        public byte mGroup1 { get; set; }
        public byte mGroup2 { get; set; }
        public short RIsCreateCnt { get; set; }
    }

    public class DT_RefineMaterial
    {
        public int RID { get; set; }
        public int RItemID { get; set; }
        public int RNum { get; set; }
        public byte ROrderNo { get; set; }
    }

    public class Zatochka
    {
        public int item_id { get; set; }
        public int id_tochki { get; set; }
    }

    public class DT_AchieveList
    {
        public int mID { get; set; }
        public string mNameKey { get; set; }
        public int mValue { get; set; }
        public string mDescKey { get; set; }
    }

    public class DT_AchieveItemCoin
    {
        public int IID { get; set; }
        public byte mGrade { get; set; }
        public byte mRarity { get; set; }
    }

    public class DT_AchieveItemTrophy
    {
        public int IID { get; set; }
        public byte mRarity { get; set; }
        public byte mEquipType { get; set; }
        public byte mEquipPos { get; set; }
        public byte mAbilityType { get; set; }
    }

    public class DT_AchieveGuildList
    {
        public int mAchieveGuildID { get; set; }
        public byte mGuildRank { get; set; }
        public string mGuildNamekey { get; set; }
        public string mMemberNameKey { get; set; }
    }

    public class TP_Servant
    {
        public short SType { get; set; }
        public string STypeNameKey { get; set; }
    }

    public class TblServantType
    {
        public int IID { get; set; }
        public short SCategory { get; set; }
        public byte SEvolutionStep { get; set; }
        public short SType { get; set; }
    }

    public class TblServantCombineAddAbility
    {
        public short SStuffType { get; set; }
        public byte SIsCoreGold { get; set; }
        public byte SIsStuffGold { get; set; }
        public byte SStrMax { get; set; }
        public byte SDexMax { get; set; }
        public byte SIntMax { get; set; }
        public byte STotalMin { get; set; }
        public byte STotalMax { get; set; }
    }

    public class TblServantSkillTree
    {
        public int IID { get; set; }
        public byte SStep { get; set; }
        public int STID1 { get; set; }
        public int STID2 { get; set; }
        public int STID3 { get; set; }
    }

    public class TblServantEvolution
    {
        public int IID { get; set; }
        public int STID1 { get; set; }
        public int STID2 { get; set; }
        public int RID { get; set; }
    }

    public class DT_SkillEnhancement
    {
        public int mESPID { get; set; }
        public int mSPID { get; set; }
        public byte mOrderNo { get; set; }
        public byte mUseClass { get; set; }
    }

    public class DT_SkillEnhancementMaterial
    {
        public int mESPID { get; set; }
        public byte mOrderNo { get; set; }
        public int mItemID { get; set; }
        public int mCnt { get; set; }
    }

    public class TblOtherMerchantInfo
    {
        public int mMerchantID { get; set; }
        public int mMaxBuyItemCnt { get; set; }
        public byte mMaxTrayCnt { get; set; }
    }

    public class TP_SkillTree
    {
        public int mSTID { get; set; }
        public string mName { get; set; }
    }

    public class DT_SkillTreeNode
    {
        public int mSTNID { get; set; }
        public int mSTID { get; set; }
        public string mName { get; set; }
        public short mMaxLevel { get; set; }
        public short mNodeType { get; set; }
        public short mIconSlotX { get; set; }
        public short mIconSlotY { get; set; }
        public short mLineN { get; set; }
        public short mLineE { get; set; }
        public short mLineS { get; set; }
        public short mLineW { get; set; }
        public short mTermOfValidity { get; set; }
    }

    public class DT_SkillTreeNodeItem
    {
        public int mSTNIID { get; set; }
        public int mSTNID { get; set; }
        public int mSPID { get; set; }
        public short mLevel { get; set; }
    }

    public class DT_SkillTreeNodeItemCondition
    {
        public int mSTNIID { get; set; }
        public int mSTNICType { get; set; }
        public int mParamA { get; set; }
        public int mParamB { get; set; }
        public int mParamC { get; set; }
    }

    public class DT_SkillPack
    {
        public int mSPID { get; set; }
        public string mName { get; set; }
        public int mIType { get; set; }
        public int mIUseType { get; set; }
        public short mISubType { get; set; }
        public short mTermOfValidity { get; set; }
        public string mDesc { get; set; }
        public string mUseMsg { get; set; }
        public short mUseRange { get; set; }
        public short mUseClass { get; set; }
        public short mUseLevel { get; set; }
        public string mSpriteFile { get; set; }
        public int mSpriteX { get; set; }
        public int mSpriteY { get; set; }
        public short mIsDrop { get; set; }
    }

    public class DT_SkillPackSkill
    {
        public int mSPID { get; set; }
        public int mSID { get; set; }
        public short mSOrderNO { get; set; }
    }
}