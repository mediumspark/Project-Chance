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
        static const AkUniqueID PLAY_GROUND_ENEMY_MELEE_BIGGER_FOOTSTEPS = 3197540882U;
        static const AkUniqueID PLAY_GROUND_ENEMY_RANGED_ATTACK = 2336839859U;
        static const AkUniqueID PLAY_PHILANTHROPIST_ATTACK = 1763307192U;
        static const AkUniqueID PLAY_PHILANTHROPIST_DAMAGED = 3376220201U;
        static const AkUniqueID PLAY_PHILANTHROPIST_FOOTSTEPS = 3615605441U;
        static const AkUniqueID PLAY_PLAYER_ATTACK = 3238800884U;
        static const AkUniqueID PLAY_PLAYER_DAMAGED = 2301987285U;
        static const AkUniqueID PLAY_PLAYER_FOOTSTEPS = 98439365U;
        static const AkUniqueID PLAY_PLAYER_GROUND_SLIDE = 3964574843U;
        static const AkUniqueID PLAY_PLAYER_LOWHEALTH = 3851267176U;
        static const AkUniqueID STOP_AIR_ENEMY_FLYING = 3664791045U;
    } // namespace EVENTS

    namespace STATES
    {
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
        namespace ATTACK_RECEIVER
        {
            static const AkUniqueID GROUP = 1211767367U;

            namespace SWITCH
            {
                static const AkUniqueID PERSON = 1731679510U;
                static const AkUniqueID ROBOT = 1930240631U;
            } // namespace SWITCH
        } // namespace ATTACK_RECEIVER

    } // namespace SWITCHES

    namespace BANKS
    {
        static const AkUniqueID INIT = 1355168291U;
        static const AkUniqueID DEFAULT_SOUNDBANK = 2218482606U;
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
