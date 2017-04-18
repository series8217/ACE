﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACE.Network.Enum
{
    public enum MotionCommand
    {
        Invalid,
        HoldRun,
        HoldSidestep,
        Ready,
        Stop,
        WalkForward,
        WalkBackwards,
        RunForward,
        Fallen,
        Interpolating,
        Hover,
        On,
        Off,
        TurnRight,
        TurnLeft,
        SideStepRight,
        SideStepLeft,
        Dead,
        Crouch,
        Sitting,
        Sleeping,
        Falling,
        Reload,
        Unload,
        Pickup,
        StoreInBackpack,
        Eat,
        Drink,
        Reading,
        JumpCharging,
        AimLevel,
        AimHigh15,
        AimHigh30,
        AimHigh45,
        AimHigh60,
        AimHigh75,
        AimHigh90,
        AimLow15,
        AimLow30,
        AimLow45,
        AimLow60,
        AimLow75,
        AimLow90,
        MagicBlast,
        MagicSelfHead,
        MagicSelfHeart,
        MagicBonus,
        MagicClap,
        MagicHarm,
        MagicHeal,
        MagicThrowMissile,
        MagicRecoilMissile,
        MagicPenalty,
        MagicTransfer,
        MagicVision,
        MagicEnchantItem,
        MagicPortal,
        MagicPray,
        StopTurning,
        Jump,
        HandCombat,
        NonCombat,
        SwordCombat,
        BowCombat,
        SwordShieldCombat,
        CrossbowCombat,
        UnusedCombat,
        SlingCombat,
        TwoHandedSwordCombat,
        TwoHandedStaffCombat,
        DualWieldCombat,
        ThrownWeaponCombat,
        Graze,
        Magi,
        Hop,
        Jumpup,
        Cheer,
        ChestBeat,
        TippedLeft,
        TippedRight,
        FallDown,
        Twitch1,
        Twitch2,
        Twitch3,
        Twitch4,
        StaggerBackward,
        StaggerForward,
        Sanctuary,
        ThrustMed,
        ThrustLow,
        ThrustHigh,
        SlashHigh,
        SlashMed,
        SlashLow,
        BackhandHigh,
        BackhandMed,
        BackhandLow,
        Shoot,
        AttackHigh1,
        AttackMed1,
        AttackLow1,
        AttackHigh2,
        AttackMed2,
        AttackLow2,
        AttackHigh3,
        AttackMed3,
        AttackLow3,
        HeadThrow,
        FistSlam,
        BreatheFlame_,
        SpinAttack,
        MagicPowerUp01,
        MagicPowerUp02,
        MagicPowerUp03,
        MagicPowerUp04,
        MagicPowerUp05,
        MagicPowerUp06,
        MagicPowerUp07,
        MagicPowerUp08,
        MagicPowerUp09,
        MagicPowerUp10,
        ShakeFist,
        Beckon,
        BeSeeingYou,
        BlowKiss,
        BowDeep,
        ClapHands,
        Cry,
        Laugh,
        MimeEat,
        MimeDrink,
        Nod,
        Point,
        ShakeHead,
        Shrug,
        Wave,
        Akimbo,
        HeartyLaugh,
        Salute,
        ScratchHead,
        SmackHead,
        TapFoot,
        WaveHigh,
        WaveLow,
        YawnStretch,
        Cringe,
        Kneel,
        Plead,
        Shiver,
        Shoo,
        Slouch,
        Spit,
        Surrender,
        Woah,
        Winded,
        YMCA,
        EnterGame,
        ExitGame,
        OnCreation,
        OnDestruction,
        EnterPortal,
        ExitPortal,
        Cancel,
        UseSelected,
        AutosortSelected,
        DropSelected,
        GiveSelected,
        SplitSelected,
        ExamineSelected,
        CreateShortcutToSelected,
        PreviousCompassItem,
        NextCompassItem,
        ClosestCompassItem,
        PreviousSelection,
        LastAttacker,
        PreviousFellow,
        NextFellow,
        ToggleCombat,
        HighAttack,
        MediumAttack,
        LowAttack,
        EnterChat,
        ToggleChat,
        SavePosition,
        OptionsPanel,
        ResetView,
        CameraLeftRotate,
        CameraRightRotate,
        CameraRaise,
        CameraLower,
        CameraCloser,
        CameraFarther,
        FloorView,
        MouseLook,
        PreviousItem,
        NextItem,
        ClosestItem,
        ShiftView,
        MapView,
        AutoRun,
        DecreasePowerSetting,
        IncreasePowerSetting,
        Pray,
        Mock,
        Teapot,
        SpecialAttack1,
        SpecialAttack2,
        SpecialAttack3,
        MissileAttack1,
        MissileAttack2,
        MissileAttack3,
        CastSpell,
        Flatulence,
        FirstPersonView,
        AllegiancePanel,
        FellowshipPanel,
        SpellbookPanel,
        SpellComponentsPanel,
        HousePanel,
        AttributesPanel,
        SkillsPanel,
        MapPanel,
        InventoryPanel,
        Demonet,
        UseMagicStaff,
        UseMagicWand,
        Blink,
        Bite,
        TwitchSubstate1,
        TwitchSubstate2,
        TwitchSubstate3,
        CaptureScreenshotToFile,
        BowNoAmmo,
        CrossBowNoAmmo,
        ShakeFistState,
        PrayState,
        BowDeepState,
        ClapHandsState,
        CrossArmsState,
        ShiverState,
        PointState,
        WaveState,
        AkimboState,
        SaluteState,
        ScratchHeadState,
        TapFootState,
        LeanState,
        KneelState,
        PleadState,
        ATOYOT,
        SlouchState,
        SurrenderState,
        WoahState,
        WindedState,
        AutoCreateShortcuts,
        AutoRepeatAttacks,
        AutoTarget,
        AdvancedCombatInterface,
        IgnoreAllegianceRequests,
        IgnoreFellowshipRequests,
        InvertMouseLook,
        LetPlayersGiveYouItems,
        AutoTrackCombatTargets,
        DisplayTooltips,
        AttemptToDeceivePlayers,
        RunAsDefaultMovement,
        StayInChatModeAfterSend,
        RightClickToMouseLook,
        VividTargetIndicator,
        SelectSelf,
        SkillHealSelf,
        NextMonster,
        PreviousMonster,
        ClosestMonster,
        NextPlayer,
        PreviousPlayer,
        ClosestPlayer,
        SnowAngelState = 280,
        WarmHands,
        CurtseyState,
        AFKState,
        MeditateState,
        TradePanel,
        LogOut,
        DoubleSlashLow,
        DoubleSlashMed,
        DoubleSlashHigh,
        TripleSlashLow,
        TripleSlashMed,
        TripleSlashHigh,
        DoubleThrustLow,
        DoubleThrustMed,
        DoubleThrustHigh,
        TripleThrustLow,
        TripleThrustMed,
        TripleThrustHigh,
        MagicPowerUp01Purple,
        MagicPowerUp02Purple,
        MagicPowerUp03Purple,
        MagicPowerUp04Purple,
        MagicPowerUp05Purple,
        MagicPowerUp06Purple,
        MagicPowerUp07Purple,
        MagicPowerUp08Purple,
        MagicPowerUp09Purple,
        MagicPowerUp10Purple,
        Helper,
        Pickup5,
        Pickup10,
        Pickup15,
        Pickup20,
        HouseRecall,
        AtlatlCombat,
        ThrownShieldCombat,
        SitState,
        SitCrossleggedState,
        SitBackState,
        PointLeftState,
        PointRightState,
        TalktotheHandState,
        PointDownState,
        DrudgeDanceState,
        PossumState,
        ReadState,
        ThinkerState,
        HaveASeatState,
        AtEaseState,
        NudgeLeft,
        NudgeRight,
        PointLeft,
        PointRight,
        PointDown,
        Knock,
        ScanHorizon,
        DrudgeDance,
        HaveASeat,
        LifestoneRecall,
        CharacterOptionsPanel,
        SoundAndGraphicsPanel,
        HelpfulSpellsPanel,
        HarmfulSpellsPanel,
        CharacterInformationPanel,
        LinkStatusPanel,
        VitaePanel,
        ShareFellowshipXP,
        ShareFellowshipLoot,
        AcceptCorpseLooting,
        IgnoreTradeRequests,
        DisableWeather,
        DisableHouseEffect,
        SideBySideVitals,
        ShowRadarCoordinates,
        ShowSpellDurations,
        MuteOnLosingFocus,
        Fishing,
        MarketplaceRecall,
        EnterPKLite,
        AllegianceChat,
        AutomaticallyAcceptFellowshipRequests,
        Reply,
        MonarchReply,
        PatronReply,
        ToggleCraftingChanceOfSuccessDialog,
        UseClosestUnopenedCorpse,
        UseNextUnopenedCorpse,
        IssueSlashCommand,
        AllegianceHometownRecall,
        PKArenaRecall,
        OffhandSlashHigh,
        OffhandSlashMed,
        OffhandSlashLow,
        OffhandThrustHigh,
        OffhandThrustMed,
        OffhandThrustLow,
        OffhandDoubleSlashLow,
        OffhandDoubleSlashMed,
        OffhandDoubleSlashHigh,
        OffhandTripleSlashLow,
        OffhandTripleSlashMed,
        OffhandTripleSlashHigh,
        OffhandDoubleThrustLow,
        OffhandDoubleThrustMed,
        OffhandDoubleThrustHigh,
        OffhandTripleThrustLow,
        OffhandTripleThrustMed,
        OffhandTripleThrustHigh,
        OffhandKick,
        AttackHigh4,
        AttackMed4,
        AttackLow4,
        AttackHigh5,
        AttackMed5,
        AttackLow5,
        AttackHigh6,
        AttackMed6,
        AttackLow6,
        PunchFastHigh,
        PunchFastMed,
        PunchFastLow,
        PunchSlowHigh,
        PunchSlowMed,
        PunchSlowLow,
        OffhandPunchFastHigh,
        OffhandPunchFastMed,
        OffhandPunchFastLow,
        OffhandPunchSlowHigh,
        OffhandPunchSlowMed,
        OffhandPunchSlowLow
    }
}