//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from: Protocol/HS.proto
namespace PB
{
    [global::ProtoBuf.ProtoContract(Name=@"sys")]
    public enum sys
    {
            
      [global::ProtoBuf.ProtoEnum(Name=@"DATA_WRAPPER", Value=1)]
      DATA_WRAPPER = 1,
            
      [global::ProtoBuf.ProtoEnum(Name=@"KEY_EXCHANGE", Value=2)]
      KEY_EXCHANGE = 2,
            
      [global::ProtoBuf.ProtoEnum(Name=@"HEART_BEAT", Value=3)]
      HEART_BEAT = 3,
            
      [global::ProtoBuf.ProtoEnum(Name=@"ERROR_CODE", Value=4)]
      ERROR_CODE = 4
    }
  
    [global::ProtoBuf.ProtoContract(Name=@"gm")]
    public enum gm
    {
            
      [global::ProtoBuf.ProtoEnum(Name=@"GEN_TEST_ACCOUNT", Value=100)]
      GEN_TEST_ACCOUNT = 100,
            
      [global::ProtoBuf.ProtoEnum(Name=@"GMOPERATION_C", Value=101)]
      GMOPERATION_C = 101,
            
      [global::ProtoBuf.ProtoEnum(Name=@"GMOPERATION_S", Value=102)]
      GMOPERATION_S = 102
    }
  
    [global::ProtoBuf.ProtoContract(Name=@"code")]
    public enum code
    {
            
      [global::ProtoBuf.ProtoEnum(Name=@"LOGIN_C", Value=1000)]
      LOGIN_C = 1000,
            
      [global::ProtoBuf.ProtoEnum(Name=@"LOGIN_S", Value=1001)]
      LOGIN_S = 1001,
            
      [global::ProtoBuf.ProtoEnum(Name=@"LOGOUT_C", Value=1002)]
      LOGOUT_C = 1002,
            
      [global::ProtoBuf.ProtoEnum(Name=@"LOGOUT_S", Value=1003)]
      LOGOUT_S = 1003,
            
      [global::ProtoBuf.ProtoEnum(Name=@"KICKOUT_S", Value=1004)]
      KICKOUT_S = 1004,
            
      [global::ProtoBuf.ProtoEnum(Name=@"SYNCINFO_C", Value=1005)]
      SYNCINFO_C = 1005,
            
      [global::ProtoBuf.ProtoEnum(Name=@"SYNCINFO_S", Value=1006)]
      SYNCINFO_S = 1006,
            
      [global::ProtoBuf.ProtoEnum(Name=@"PLAYER_INFO_SYNC_S", Value=1010)]
      PLAYER_INFO_SYNC_S = 1010,
            
      [global::ProtoBuf.ProtoEnum(Name=@"STATISTICS_INFO_SYNC_S", Value=1011)]
      STATISTICS_INFO_SYNC_S = 1011,
            
      [global::ProtoBuf.ProtoEnum(Name=@"SETTING_INFO_SYNC_S", Value=1012)]
      SETTING_INFO_SYNC_S = 1012,
            
      [global::ProtoBuf.ProtoEnum(Name=@"MONSTER_INFO_SYNC_S", Value=1013)]
      MONSTER_INFO_SYNC_S = 1013,
            
      [global::ProtoBuf.ProtoEnum(Name=@"ITEM_INFO_SYNC_S", Value=1014)]
      ITEM_INFO_SYNC_S = 1014,
            
      [global::ProtoBuf.ProtoEnum(Name=@"EQUIP_INFO_SYNC_S", Value=1015)]
      EQUIP_INFO_SYNC_S = 1015,
            
      [global::ProtoBuf.ProtoEnum(Name=@"QUEST_INFO_SYNC_S", Value=1016)]
      QUEST_INFO_SYNC_S = 1016,
            
      [global::ProtoBuf.ProtoEnum(Name=@"MAIL_INFO_SYNC_S", Value=1017)]
      MAIL_INFO_SYNC_S = 1017,
            
      [global::ProtoBuf.ProtoEnum(Name=@"ASSEMBLE_FINISH_S", Value=1018)]
      ASSEMBLE_FINISH_S = 1018,
            
      [global::ProtoBuf.ProtoEnum(Name=@"PLAYER_CREATE_C", Value=1101)]
      PLAYER_CREATE_C = 1101,
            
      [global::ProtoBuf.ProtoEnum(Name=@"PLAYER_CREATE_S", Value=1102)]
      PLAYER_CREATE_S = 1102,
            
      [global::ProtoBuf.ProtoEnum(Name=@"PLAYER_CONSUME_S", Value=1103)]
      PLAYER_CONSUME_S = 1103,
            
      [global::ProtoBuf.ProtoEnum(Name=@"PLAYER_REWARD_S", Value=1104)]
      PLAYER_REWARD_S = 1104,
            
      [global::ProtoBuf.ProtoEnum(Name=@"MONSTER_ADD_S", Value=2001)]
      MONSTER_ADD_S = 2001,
            
      [global::ProtoBuf.ProtoEnum(Name=@"MONSTER_CATCH_C", Value=2002)]
      MONSTER_CATCH_C = 2002,
            
      [global::ProtoBuf.ProtoEnum(Name=@"MONSTER_CATCH_S", Value=2003)]
      MONSTER_CATCH_S = 2003,
            
      [global::ProtoBuf.ProtoEnum(Name=@"MONSTER_BREAK_C", Value=2004)]
      MONSTER_BREAK_C = 2004,
            
      [global::ProtoBuf.ProtoEnum(Name=@"MONSTER_BREAK_S", Value=2005)]
      MONSTER_BREAK_S = 2005,
            
      [global::ProtoBuf.ProtoEnum(Name=@"MONSTER_FEED_C", Value=2006)]
      MONSTER_FEED_C = 2006,
            
      [global::ProtoBuf.ProtoEnum(Name=@"MONSTER_FEED_S", Value=2007)]
      MONSTER_FEED_S = 2007,
            
      [global::ProtoBuf.ProtoEnum(Name=@"MONSTER_SKILL_UP_C", Value=2008)]
      MONSTER_SKILL_UP_C = 2008,
            
      [global::ProtoBuf.ProtoEnum(Name=@"MONSTER_SKILL_UP_S", Value=2009)]
      MONSTER_SKILL_UP_S = 2009,
            
      [global::ProtoBuf.ProtoEnum(Name=@"MONSTER_STAGE_UP_C", Value=2010)]
      MONSTER_STAGE_UP_C = 2010,
            
      [global::ProtoBuf.ProtoEnum(Name=@"MONSTER_STAGE_UP_S", Value=2011)]
      MONSTER_STAGE_UP_S = 2011,
            
      [global::ProtoBuf.ProtoEnum(Name=@"MONSTER_LOCK_C", Value=2012)]
      MONSTER_LOCK_C = 2012,
            
      [global::ProtoBuf.ProtoEnum(Name=@"MONSTER_LOCK_S", Value=2013)]
      MONSTER_LOCK_S = 2013,
            
      [global::ProtoBuf.ProtoEnum(Name=@"INSTANCE_ASSIST_C", Value=3001)]
      INSTANCE_ASSIST_C = 3001,
            
      [global::ProtoBuf.ProtoEnum(Name=@"INSTANCE_ASSIST_S", Value=3002)]
      INSTANCE_ASSIST_S = 3002,
            
      [global::ProtoBuf.ProtoEnum(Name=@"INSTANCE_ENTER_C", Value=3003)]
      INSTANCE_ENTER_C = 3003,
            
      [global::ProtoBuf.ProtoEnum(Name=@"INSTANCE_ENTER_S", Value=3004)]
      INSTANCE_ENTER_S = 3004,
            
      [global::ProtoBuf.ProtoEnum(Name=@"INSTANCE_SETTLE_C", Value=3005)]
      INSTANCE_SETTLE_C = 3005,
            
      [global::ProtoBuf.ProtoEnum(Name=@"INSTANCE_SETTLE_S", Value=3006)]
      INSTANCE_SETTLE_S = 3006,
            
      [global::ProtoBuf.ProtoEnum(Name=@"INSTANCE_OPEN_CARD_C", Value=3007)]
      INSTANCE_OPEN_CARD_C = 3007,
            
      [global::ProtoBuf.ProtoEnum(Name=@"INSTANCE_OPEN_CARD_S", Value=3008)]
      INSTANCE_OPEN_CARD_S = 3008,
            
      [global::ProtoBuf.ProtoEnum(Name=@"INSTANCE_SWEEP_C", Value=3009)]
      INSTANCE_SWEEP_C = 3009,
            
      [global::ProtoBuf.ProtoEnum(Name=@"INSTANCE_SWEEP_S", Value=3010)]
      INSTANCE_SWEEP_S = 3010,
            
      [global::ProtoBuf.ProtoEnum(Name=@"INSTANCE_RESET_COUNT_C", Value=3011)]
      INSTANCE_RESET_COUNT_C = 3011,
            
      [global::ProtoBuf.ProtoEnum(Name=@"INSTANCE_RESET_COUNT_S", Value=3012)]
      INSTANCE_RESET_COUNT_S = 3012,
            
      [global::ProtoBuf.ProtoEnum(Name=@"INSTANCE_REVIVE_C", Value=3013)]
      INSTANCE_REVIVE_C = 3013,
            
      [global::ProtoBuf.ProtoEnum(Name=@"INSTANCE_REVIVE_S", Value=3014)]
      INSTANCE_REVIVE_S = 3014,
            
      [global::ProtoBuf.ProtoEnum(Name=@"ITEM_USE_C", Value=4001)]
      ITEM_USE_C = 4001,
            
      [global::ProtoBuf.ProtoEnum(Name=@"ITEM_USE_S", Value=4002)]
      ITEM_USE_S = 4002,
            
      [global::ProtoBuf.ProtoEnum(Name=@"ITEM_BOX_USE_BATCH_C", Value=4003)]
      ITEM_BOX_USE_BATCH_C = 4003,
            
      [global::ProtoBuf.ProtoEnum(Name=@"ITEM_BOX_USE_BATCH_S", Value=4004)]
      ITEM_BOX_USE_BATCH_S = 4004,
            
      [global::ProtoBuf.ProtoEnum(Name=@"ITEM_SELL_C", Value=4005)]
      ITEM_SELL_C = 4005,
            
      [global::ProtoBuf.ProtoEnum(Name=@"ITEM_SELL_S", Value=4006)]
      ITEM_SELL_S = 4006,
            
      [global::ProtoBuf.ProtoEnum(Name=@"ITEM_SELL_BATCH_C", Value=4007)]
      ITEM_SELL_BATCH_C = 4007,
            
      [global::ProtoBuf.ProtoEnum(Name=@"ITEM_SELL_BATCH_S", Value=4008)]
      ITEM_SELL_BATCH_S = 4008,
            
      [global::ProtoBuf.ProtoEnum(Name=@"ITEM_BUY_C", Value=4009)]
      ITEM_BUY_C = 4009,
            
      [global::ProtoBuf.ProtoEnum(Name=@"ITEM_BUY_S", Value=4010)]
      ITEM_BUY_S = 4010,
            
      [global::ProtoBuf.ProtoEnum(Name=@"ITEM_COMPOSE_C", Value=4011)]
      ITEM_COMPOSE_C = 4011,
            
      [global::ProtoBuf.ProtoEnum(Name=@"ITEM_COMPOSE_S", Value=4012)]
      ITEM_COMPOSE_S = 4012,
            
      [global::ProtoBuf.ProtoEnum(Name=@"EQUIP_SELL_C", Value=4101)]
      EQUIP_SELL_C = 4101,
            
      [global::ProtoBuf.ProtoEnum(Name=@"EQUIP_SELL_S", Value=4102)]
      EQUIP_SELL_S = 4102,
            
      [global::ProtoBuf.ProtoEnum(Name=@"EQUIP_BUY_C", Value=4103)]
      EQUIP_BUY_C = 4103,
            
      [global::ProtoBuf.ProtoEnum(Name=@"EQUIP_BUY_S", Value=4104)]
      EQUIP_BUY_S = 4104,
            
      [global::ProtoBuf.ProtoEnum(Name=@"EQUIP_COMPOSE_C", Value=4105)]
      EQUIP_COMPOSE_C = 4105,
            
      [global::ProtoBuf.ProtoEnum(Name=@"EQUIP_COMPOSE_S", Value=4106)]
      EQUIP_COMPOSE_S = 4106,
            
      [global::ProtoBuf.ProtoEnum(Name=@"EQUIP_INCREASE_LEVEL_C", Value=4107)]
      EQUIP_INCREASE_LEVEL_C = 4107,
            
      [global::ProtoBuf.ProtoEnum(Name=@"EQUIP_INCREASE_LEVEL_S", Value=4108)]
      EQUIP_INCREASE_LEVEL_S = 4108,
            
      [global::ProtoBuf.ProtoEnum(Name=@"EQUIP_INCREASE_STAGE_C", Value=4109)]
      EQUIP_INCREASE_STAGE_C = 4109,
            
      [global::ProtoBuf.ProtoEnum(Name=@"EQUIP_INCREASE_STAGE_S", Value=4110)]
      EQUIP_INCREASE_STAGE_S = 4110,
            
      [global::ProtoBuf.ProtoEnum(Name=@"EQUIP_PUNCH_C", Value=4111)]
      EQUIP_PUNCH_C = 4111,
            
      [global::ProtoBuf.ProtoEnum(Name=@"EQUIP_PUNCH_S", Value=4112)]
      EQUIP_PUNCH_S = 4112,
            
      [global::ProtoBuf.ProtoEnum(Name=@"EQUIP_GEM_C", Value=4113)]
      EQUIP_GEM_C = 4113,
            
      [global::ProtoBuf.ProtoEnum(Name=@"EQUIP_GEM_S", Value=4114)]
      EQUIP_GEM_S = 4114,
            
      [global::ProtoBuf.ProtoEnum(Name=@"EQUIP_MONSTER_DRESS_C", Value=4120)]
      EQUIP_MONSTER_DRESS_C = 4120,
            
      [global::ProtoBuf.ProtoEnum(Name=@"EQUIP_MONSTER_DRESS_S", Value=4121)]
      EQUIP_MONSTER_DRESS_S = 4121,
            
      [global::ProtoBuf.ProtoEnum(Name=@"EQUIP_MONSTER_UNDRESS_C", Value=4122)]
      EQUIP_MONSTER_UNDRESS_C = 4122,
            
      [global::ProtoBuf.ProtoEnum(Name=@"EQUIP_MONSTER_UNDRESS_S", Value=4123)]
      EQUIP_MONSTER_UNDRESS_S = 4123,
            
      [global::ProtoBuf.ProtoEnum(Name=@"EQUIP_MONSTER_REPLACE_C", Value=4124)]
      EQUIP_MONSTER_REPLACE_C = 4124,
            
      [global::ProtoBuf.ProtoEnum(Name=@"EQUIP_MONSTER_REPLACE_S", Value=4125)]
      EQUIP_MONSTER_REPLACE_S = 4125,
            
      [global::ProtoBuf.ProtoEnum(Name=@"QUEST_SUBMIT_C", Value=5001)]
      QUEST_SUBMIT_C = 5001,
            
      [global::ProtoBuf.ProtoEnum(Name=@"QUEST_SUBMIT_S", Value=5002)]
      QUEST_SUBMIT_S = 5002,
            
      [global::ProtoBuf.ProtoEnum(Name=@"QUEST_ACCEPT_S", Value=5003)]
      QUEST_ACCEPT_S = 5003,
            
      [global::ProtoBuf.ProtoEnum(Name=@"QUEST_UPDATE_S", Value=5004)]
      QUEST_UPDATE_S = 5004,
            
      [global::ProtoBuf.ProtoEnum(Name=@"QUEST_REMOVE_S", Value=5005)]
      QUEST_REMOVE_S = 5005,
            
      [global::ProtoBuf.ProtoEnum(Name=@"MAIL_READ_C", Value=6001)]
      MAIL_READ_C = 6001,
            
      [global::ProtoBuf.ProtoEnum(Name=@"MAIL_RECEIVE_C", Value=6002)]
      MAIL_RECEIVE_C = 6002,
            
      [global::ProtoBuf.ProtoEnum(Name=@"MAIL_RECEIVE_S", Value=6003)]
      MAIL_RECEIVE_S = 6003,
            
      [global::ProtoBuf.ProtoEnum(Name=@"MAIL_RECEIVE_ALL_C", Value=6004)]
      MAIL_RECEIVE_ALL_C = 6004,
            
      [global::ProtoBuf.ProtoEnum(Name=@"MAIL_RECEIVE_ALL_S", Value=6005)]
      MAIL_RECEIVE_ALL_S = 6005,
            
      [global::ProtoBuf.ProtoEnum(Name=@"MAIL_NEW_S", Value=6006)]
      MAIL_NEW_S = 6006,
            
      [global::ProtoBuf.ProtoEnum(Name=@"IM_CHAT_SEND_C", Value=7001)]
      IM_CHAT_SEND_C = 7001,
            
      [global::ProtoBuf.ProtoEnum(Name=@"IM_PUSH_S", Value=7002)]
      IM_PUSH_S = 7002,
            
      [global::ProtoBuf.ProtoEnum(Name=@"IM_PLAYER_GET_C", Value=7003)]
      IM_PLAYER_GET_C = 7003,
            
      [global::ProtoBuf.ProtoEnum(Name=@"IM_PLAYER_GET_S", Value=7004)]
      IM_PLAYER_GET_S = 7004,
            
      [global::ProtoBuf.ProtoEnum(Name=@"SHOP_DATA_INIT_C", Value=8001)]
      SHOP_DATA_INIT_C = 8001,
            
      [global::ProtoBuf.ProtoEnum(Name=@"SHOP_DATA_INIT_S", Value=8002)]
      SHOP_DATA_INIT_S = 8002,
            
      [global::ProtoBuf.ProtoEnum(Name=@"SHOP_REFRESH_C", Value=8003)]
      SHOP_REFRESH_C = 8003,
            
      [global::ProtoBuf.ProtoEnum(Name=@"SHOP_REFRESH_S", Value=8004)]
      SHOP_REFRESH_S = 8004,
            
      [global::ProtoBuf.ProtoEnum(Name=@"SHOP_ITEM_BUY_C", Value=8005)]
      SHOP_ITEM_BUY_C = 8005,
            
      [global::ProtoBuf.ProtoEnum(Name=@"SHOP_ITEM_BUY_S", Value=8006)]
      SHOP_ITEM_BUY_S = 8006,
            
      [global::ProtoBuf.ProtoEnum(Name=@"SHOP_DATA_SYN_C", Value=8007)]
      SHOP_DATA_SYN_C = 8007,
            
      [global::ProtoBuf.ProtoEnum(Name=@"SHOP_DATA_SYN_S", Value=8008)]
      SHOP_DATA_SYN_S = 8008,
            
      [global::ProtoBuf.ProtoEnum(Name=@"SHOP_GOLD2COIN_C", Value=8009)]
      SHOP_GOLD2COIN_C = 8009,
            
      [global::ProtoBuf.ProtoEnum(Name=@"SHOP_GOLD2COIN_S", Value=8010)]
      SHOP_GOLD2COIN_S = 8010,
            
      [global::ProtoBuf.ProtoEnum(Name=@"SHOP_REFRESH_TIMES", Value=8011)]
      SHOP_REFRESH_TIMES = 8011,
            
      [global::ProtoBuf.ProtoEnum(Name=@"ALLIANCE_CREATE_C", Value=9001)]
      ALLIANCE_CREATE_C = 9001,
            
      [global::ProtoBuf.ProtoEnum(Name=@"ALLIANCE_CREATE_S", Value=9002)]
      ALLIANCE_CREATE_S = 9002,
            
      [global::ProtoBuf.ProtoEnum(Name=@"SETTING_LANGUAGE_C", Value=10001)]
      SETTING_LANGUAGE_C = 10001,
            
      [global::ProtoBuf.ProtoEnum(Name=@"SETTING_LANGUAGE_S", Value=10002)]
      SETTING_LANGUAGE_S = 10002,
            
      [global::ProtoBuf.ProtoEnum(Name=@"SETTING_BLOCK_C", Value=10003)]
      SETTING_BLOCK_C = 10003,
            
      [global::ProtoBuf.ProtoEnum(Name=@"SETTING_BLOCK_S", Value=10004)]
      SETTING_BLOCK_S = 10004,
            
      [global::ProtoBuf.ProtoEnum(Name=@"STATISTICS_EXP_LEFT_TIMES", Value=11001)]
      STATISTICS_EXP_LEFT_TIMES = 11001,
            
      [global::ProtoBuf.ProtoEnum(Name=@"STATISTICS_RESET_SYN", Value=11002)]
      STATISTICS_RESET_SYN = 11002
    }
  
}