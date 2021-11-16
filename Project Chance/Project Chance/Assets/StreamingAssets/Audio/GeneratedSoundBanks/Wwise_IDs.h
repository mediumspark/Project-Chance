/////////////////////////////////////////////////////////////////////////////////////////////////////
//
// Audiokinetic Wwise generated include file. Do not edit.
//
/////////////////////////////////////////////////////////////////////////////////////////////////////

#ifndef __WWISE_IDS_H__
#define __WWISE_IDS_H__

#include <AK/SoundEngine/Common/AkTypes.h>

namespace AK
{
    namespace EVENTS
    {
        static const AkUniqueID PLAY_AIR_ENEMY_FLYING = 1484250099U;
        static const AkUniqueID PLAY_AIR_ENEMY_RANGED_ATTACK = 888154214U;
        static const AkUniqueID PLAY_FOOTSTEPS = 3854155799U;
        static const AkUniqueID PLAY_GROUND_ENEMY_FOOTSTEPS = 3600261322U;
        static const AkUniqueID PLAY_GROUND_ENEMY_MELEE_ATTACK = 512754046U;
        static const AkUniqueID PLAY_GROUND_ENEMY_MELEE_ATTACK_01 = 4053597708U;
        static const AkUniqueID PLAY_GROUND_ENEMY_MELEE_BIGGER_FOOTSTEPS = 3197540882U;
        static const AkUniqueID PLAY_GROUND_ENEMY_RANGED_ATTACK = 2336839859U;
        static const AkUniqueID PLAY_MAIN_CHARACTER_THEME = 1429924295U;
        static const AkUniqueID PLAY_PLAYER_ATTACK = 3238800884U;
        static const AkUniqueID PLAY_PLAYER_DAMAGED = 2301987285U;
        static const AkUniqueID PLAY_PLAYER_FALLING = 396543629U;
        static const AkUniqueID PLAY_PLAYER_GROUNDSLIDE = 1694127508U;
        static const AkUniqueID PLAY_PLAYER_JUMP = 562256996U;
        static const AkUniqueID PLAY_PLAYER_LOWHEALTH = 3851267176U;
        static const AkUniqueID STOP_PLAYER_LOWHEALTH = 898213950U;
    } // namespace EVENTS

    namespace STATES
    {
        namespace COMBAT
        {
            static const AkUniqueID GROUP = 2764240573U;

            namespace STATE
            {
                static const AkUniqueID IN_COMBAT = 2116791127U;
                static const AkUniqueID NONE = 748895195U;
                static const AkUniqueID OUT_OF_COMBAT = 3162566204U;
            } // namespace STATE
        } // namespace COMBAT

        namespace LIFE
        {
            static const AkUniqueID GROUP = 2137943U;

            namespace STATE
            {
                static const AkUniqueID ALIVE = 655265632U;
                static const AkUniqueID DEAD = 2044049779U;
                static const AkUniqueID LOW_HEALTH = 72790338U;
                static const AkUniqueID NONE = 748895195U;
            } // namespace STATE
        } // namespace LIFE

    } // namespace STATES

    namespace SWITCHES
    {
        namespace ATTACK
        {
            static const AkUniqueID GROUP = 180661997U;

            namespace SWITCH
            {
                static const AkUniqueID PERSON = 1731679510U;
                static const AkUniqueID ROBOT = 1930240631U;
            } // namespace SWITCH
        } // namespace ATTACK

        namespace MUSIC
        {
            static const AkUniqueID GROUP = 3991942870U;

            namespace SWITCH
            {
                static const AkUniqueID CHORUS = 2866621671U;
                static const AkUniqueID INTRO = 1125500713U;
                static const AkUniqueID TRANSITION = 1865857008U;
                static const AkUniqueID VERSE = 3840766212U;
            } // namespace SWITCH
        } // namespace MUSIC

    } // namespace SWITCHES

    namespace GAME_PARAMETERS
    {
        static const AkUniqueID HEALTH = 3677180323U;
    } // namespace GAME_PARAMETERS

    namespace BANKS
    {
        static const AkUniqueID INIT = 1355168291U;
        static const AkUniqueID UNCOVERED_SOUNDBANK = 965033712U;
    } // namespace BANKS

    namespace BUSSES
    {
        static const AkUniqueID MASTER_AUDIO_BUS = 3803692087U;
    } // namespace BUSSES

    namespace AUDIO_DEVICES
    {
        static const AkUniqueID NO_OUTPUT = 2317455096U;
        static const AkUniqueID SYSTEM = 3859886410U;
    } // namespace AUDIO_DEVICES

}// namespace AK

#endif // __WWISE_IDS_H__
