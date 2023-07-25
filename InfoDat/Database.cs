using System.Data.SqlClient;
using Newtonsoft.Json.Linq;

namespace InfoDat;

public class Database
{
    public string LoadData(string connectionString)
    {
        using var connection = new SqlConnection(connectionString);

        try
        {
            connection.Open();

            var queries = new Dictionary<string, string>
            {
                {
                    "DT_Item",
                    "SELECT IID, IName, IType, IMaxStack, IWeight, ITermOfValidity, ITermOfValidityMi, IDesc, IUseType, IUseNum, IStatus, IFakeID, IFakeName, IUseMsg, IRange, IUseClass, IDropEffect, IUseLevel, ILevel, IUseEternal, IUseDelay, IIsIndict, IIsCharge, IPShopItemType, INationOp, IContentsLv, IIsSealable, mSealRemovalNeedCnt, mIsPracticalPeriod, IAddShortAttackRange, IAddLongAttackRange, IGetItemFeedback, ISubType, IMaxBeadHoleCount FROM DT_Item"
                },
                { "DT_ItemSkill", "SELECT IID, SID FROM DT_ItemSkill" },
                {
                    "DT_Monster",
                    "SELECT MID, MName, MClass, MGbjType, MAiType, mAttackRange, MCastingDelay, mScale, mNationOp, IContentsLv, mIsShowHp, mSupportType, mWMapIconType, mAttackType, mIsEvent, mEventQuest FROM DT_Monster"
                },
                {
                    "DT_ItemResource",
                    "SELECT RID, ROwnerID, RType, CASE WHEN RFileName IS NULL OR RFileName = '' THEN '0' ELSE RFileName END AS RFileName, CASE WHEN RPosX IS NULL THEN 0 ELSE RPosX END AS RPosX, CASE WHEN RPosY IS NULL THEN 0 ELSE RPosY END AS RPosY FROM DT_ItemResource"
                },
                {
                    "DT_MonsterResource",
                    "SELECT RID, ROwnerID, RType, CASE WHEN RFileName IS NULL OR RFileName = '' THEN '0' ELSE RFileName END AS RFileName, CASE WHEN RPosX IS NULL THEN 0 ELSE RPosX END AS RPosX, CASE WHEN RPosY IS NULL THEN 0 ELSE RPosY END AS RPosY FROM DT_MonsterResource"
                },
                {
                    "DT_SkillIgnoreCastingDelayGroup",
                    "SELECT SGroupNo, SIgnoreGroup FROM DT_SkillIgnoreCastingDelayGroup"
                },
                {
                    "DT_Skill",
                    "SELECT SID, SName, SMPPerUse, SSpellNum, SType, SHPPerUse, SChaoUse, mApplyRace, mCastingDelay, mActiveType, mAnimation, mCastingSpeed, mSkillEffect, mCAmShakeWhenHit, mCriticalEffectWhenHit, mCoolTime, mCastingGroup, mCoolTimeGroup, mConsumeItem, mConsumeItemCnt, mConsumeItem2, mConsumeItemCnt2, mIsCancel, mIsAttack FROM DT_Skill"
                },
                {
                    "TP_AbnormalType",
                    "SELECT AType, AName, AEffect, ARemovable, AFileName, AIconX, AIconY FROM TP_AbnormalType"
                },
                { "DT_Abnormal", "SELECT AID, ALevel, AType, ADesc FROM DT_Abnormal" },
                {
                    "TblQuest",
                    "SELECT TblQuest.mQuestNo, mClass, mLevel1, mLevel2, mPreQuestNo, mIsOverlap, TblQuestRefMonster.mMonsterID AS mMonsterID1, mAbandonment, mDifficulty, mRewardNo, mScriptType, mPlace, mPosX, mPosY, mPosZ, mVisible, mTextNo, mParentNo, mFindNPC, mCompletionNPC FROM TblQuest INNER JOIN TblQuestRefMonster ON TblQuest.mQuestNo = TblQuestRefMonster.mQuestNo WHERE TblQuestRefMonster.mQuestNo NOT IN (SELECT mQuestNo FROM TblQuestRefMonster GROUP BY mQuestNo HAVING COUNT(mQuestNo) > 1)"
                },
                { "TblQuestInfo", "SELECT mQuestNo, mType, mParmA, mParmB, mParmC, mSeqNo FROM TblQuestInfo" },
                { "TblQuestCondition", "SELECT mQuestNo, mType, mID, mCnt, mSeqNo FROM TblQuestCondition" },
                {
                    "TblQuestReward",
                    "SELECT mRewardNo, mExp, mID, mCnt, mBinding, mStatus, mEffTime, mValTime FROM TblQuestReward"
                },
                { "TblRegionQuest", "SELECT mQuestNo, mQuestNmKey FROM TblRegionQuest" },
                {
                    "TblRegionQuestCondition",
                    "SELECT mQuestNo, mParmID, mBoss, mStepCnt, mStep1, mStep2, mStep3, mTotalCnt FROM TblRegionQuestCondition"
                },
                { "TP_SetItemInfo", "SELECT mSetType, mSetName FROM TP_SetItemInfo" },
                { "TblSetItemMember", "SELECT mSetType, IID FROM TblSetItemMember" },
                { "TP_SetItemEffectDesc", "SELECT mSetType, mDesc FROM TP_SetItemEffectDesc" },
                { "TblMaterialItemInfo", "SELECT IID, MType, MGrade, MLevel, MEnchant FROM TblMaterialItemInfo" },
                {
                    "ChestDrop",
                    "SELECT TblMaterialDrawMaterial.IID AS chest_id, TblMaterialDrawResult.IID AS item_id FROM TblMaterialDrawMaterial INNER JOIN TblMaterialDrawResult ON TblMaterialDrawMaterial.MDID = TblMaterialDrawResult.MDRD WHERE TblMaterialDrawMaterial.IID IN (SELECT IID FROM DT_Item WHERE IUseType = 12)"
                },
                {
                    "TblItemIncSysPossibleItem",
                    "SELECT mIID, mStatus, mCubeType, mProb, mResource, mKind FROM TblItemIncSysPossibleItem"
                },
                {
                    "DT_RefineCreateInfo",
                    "SELECT mRID, RItemID0, mSort, mCost, CASE WHEN RSuccess = 100 THEN 1 ELSE 0 END AS RSuccess, mNationOp, mGroup1, mGroup2, RIsCreateCnt FROM DT_RefineCreateInfo INNER JOIN DT_Refine ON DT_RefineCreateInfo.mRID = DT_Refine.RID WHERE RIsCreateCnt <> 0"
                },
                {
                    "DT_RefineMaterial",
                    "SELECT DT_RefineMaterial.RID, RItemID, RNum, ROrderNo FROM DT_RefineMaterial INNER JOIN DT_RefineCreateInfo ON DT_RefineCreateInfo.mRID = DT_RefineMaterial.RID WHERE DT_RefineMaterial.RID IN ( SELECT mRID FROM DT_RefineCreateInfo INNER JOIN DT_Refine ON DT_RefineCreateInfo.mRID = DT_Refine.RID WHERE RIsCreateCnt <> 0 )"
                },
                {
                    "Zatochka",
                    "SELECT Items.RItemID AS item_id, Tochki.RItemID AS id_tochki FROM (SELECT DT_RefineMaterial.RID, DT_RefineMaterial.RItemID FROM DT_Refine INNER JOIN DT_RefineMaterial ON DT_Refine.RID = DT_RefineMaterial.RID INNER JOIN DT_Item ON DT_RefineMaterial.RItemID = DT_Item.IID WHERE DT_Refine.RIsCreateCnt = 0 AND DT_RefineMaterial.RItemID IN (SELECT IID FROM DT_Item WHERE IType = 16 AND IUseType = 5)) Tochki INNER JOIN (SELECT DT_RefineMaterial.RID, DT_RefineMaterial.RItemID FROM DT_RefineMaterial WHERE DT_RefineMaterial.RItemID NOT IN (SELECT IID FROM DT_Item WHERE IType = 16 AND IUseType = 5)) Items ON Tochki.RID = Items.RID"
                },
                { "DT_AchieveList", "SELECT mID, mNameKey, mValue, mDescKey FROM DT_AchieveList" },
                { "DT_AchieveItemCoin", "SELECT IID, mGrade, mRarity FROM DT_AchieveItemCoin" },
                {
                    "DT_AchieveItemTrophy",
                    "SELECT IID, mRarity, mEquipType, mEquipPos, mAbilityType FROM DT_AchieveItemTrophy"
                },
                {
                    "DT_AchieveGuildList",
                    "SELECT mAchieveGuildID, mGuildRank, mGuildNamekey, mMemberNameKey FROM DT_AchieveGuildList"
                },
                { "TP_Servant", "SELECT SType, STypeNameKey FROM TP_Servant" },
                { "TblServantType", "SELECT IID, SCategory, SEvolutionStep, SType FROM TblServantType" },
                { "TblServantCombineAddAbility", "SELECT * FROM TblServantCombineAddAbility" },
                { "TblServantSkillTree", "SELECT IID, SStep, STID1, STID2, STID3 FROM TblServantSkillTree" },
                { "TblServantEvolution", "SELECT IID, STID1, STID2, RID FROM TblServantEvolution" },
                { "DT_SkillEnhancement", "SELECT mESPID, mSPID, mOrderNo, mUseClass FROM DT_SkillEnhancement" },
                {
                    "DT_SkillEnhancementMaterial",
                    "SELECT mESPID, mOrderNo, mItemID, mCnt FROM DT_SkillEnhancementMaterial"
                },
                { "TblOtherMerchantInfo", "SELECT mMerchantID, mMaxBuyItemCnt, mMaxTrayCnt FROM TblOtherMerchantInfo" },
                { "TP_SkillTree", "SELECT mSTID, mName FROM TP_SkillTree" },
                {
                    "DT_SkillTreeNode",
                    "SELECT mSTNID, mSTID, mName, mMaxLevel, mNodeType, mIconSlotX, mIconSlotY, mLineN, mLineE, mLineS, mLineW, mTermOfValidity FROM DT_SkillTreeNode"
                },
                { "DT_SkillTreeNodeItem", "SELECT mSTNIID, mSTNID, mSPID, mLevel FROM DT_SkillTreeNodeItem" },
                {
                    "DT_SkillTreeNodeItemCondition",
                    "SELECT mSTNIID, mSTNICType, mParamA, mParamB, mParamC FROM DT_SkillTreeNodeItemCondition"
                },
                {
                    "DT_SkillPack",
                    "SELECT mSPID, MName, mIType, mIUseType, mISubType, mTermOfValidity, mDesc, mUseMsg, mUseRange, mUseClass, mUseLevel, mSpriteFile, mSpriteX, mSpriteY, mIsDrop FROM DT_SkillPack"
                },
                { "DT_SkillPackSkill", "SELECT mSPID, mSID, mSOrderNO FROM DT_SkillPackSkill" }
            };

            var root = new JObject();
            
            foreach (var query in queries)
            {
                var structName = query.Key;
                var queryString = query.Value;
                var dataList = new JArray();

                using var command = new SqlCommand(queryString, connection);
                using var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var dataItem = new JObject();
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        var val = reader.GetValue(i);
                        if (val is bool boolValue)
                            val = boolValue ? "0" : "1";
                        
                        dataItem.Add(reader.GetName(i), val.ToString());
                    }

                    dataList.Add(dataItem);
                }

                root.Add(structName, dataList);
            }

            return root.ToString();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return new JObject().ToString();
        }
        finally
        {
            connection.Close();
        }
    }
}