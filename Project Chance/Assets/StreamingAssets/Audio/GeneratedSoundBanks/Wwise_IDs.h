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
        static const AkUniqueID PLAY_AMBIENCE = 278617630U;
        static const AkUniqueID PLAY_AMBIENCE_GROUND_ENEMY = 3545181809U;
        static const AkUniqueID PLAY_AMBIENCE_GROUND_ENEMY_BIGGER = 354821980U;
        static const AkUniqueID PLAY_FOOTSTEPS = 3854155799U;
        static const AkUniqueID PLAY_GROUND_ENEMY_FOOTSTEPS = 3600261322U;
        static const AkUniqueID PLAY_GROUND_ENEMY_MELEE_ATTACK = 512754046U;
        static const AkUniqueID PLAY_GROUND_ENEMY_MELEE_ATTACK_01 = 4053597708U;
        static const AkUniqueID PLAY_GROUND_ENEMY_MELEE_BIGGER_FOOTSTEPS = 3197540882U;
        static const AkUniqueID PLAY_GROUND_ENEMY_RANGED_ATTACK = 2336839859U;
        static const AkUniqueID PLAY_MAYOR_DAMAGED = 4069192858U;
        static const AkUniqueID PLAY_MAYOR_FOOTSTEPS = 138878230U;
        static const AkUniqueID PLAY_MAYOR_IMPACTS = 1261748742U;
        static const AkUniqueID PLAY_MAYOR_ROCKPROJECTILE = 4104657743U;
        static const AkUniqueID PLAY_MAYOR_ROCKSUMMON = 1279086127U;
        static const AkUniqueID PLAY_MUSIC_MAYOR_THEME = 1577132608U;
        static const AkUniqueID PLAY_MUSIC_PHILANTHROPIST_THEME = 1776098227U;
        static const AkUniqueID PLAY_PHILANTHROPIST_ATTACK = 1763307192U;
        static const AkUniqueID PLAY_PHILANTHROPIST_CLONE = 1108016795U;
        static const AkUniqueID PLAY_PHILANTHROPIST_DAMAGED = 3376220201U;
        static const AkUniqueID PLAY_PHILANTHROPIST_FOOTSTEPS = 3615605441U;
        static const AkUniqueID PLAY_PLAYER_ATTACK = 3238800884U;
        static const AkUniqueID PLAY_PLAYER_DAMAGED = 2301987285U;
        static const AkUniqueID PLAY_PLAYER_GROUNDSLIDE = 1694127508U;
        static const AkUniqueID PLAY_PLAYER_HEAL = 638998366U;
        static const AkUniqueID PLAY_PLAYER_LOWHEALTH = 3851267176U;
        static const AkUniqueID PLAY_SOUNDTRACK = 3884404148U;
        static const AkUniqueID RESUME_MUSIC = 2940177080U;
        static const AkUniqueID STOP_MUSIC = 2837384057U;
        static const AkUniqueID STOP_MUSIC_PHILANTHROPIST_THEME = 11724553U;
        static const AkUniqueID STOP_PLAYER_HEAL = 3607210104U;
        static const AkUniqueID STOP_PLAYER_LOWHEALTH = 898213950U;
    } // namespace EVENTS

    namespace STATES
    {
        namespace COMBAT
        {
            static const AkUniqueID GROUP = 2764240573U;

            namespace STATE
            {
                static const AkUniqueID EXPLORATION = 2582085496U;
                static const AkUniqueID FIGHT = 514064485U;
                static const AkUniqueID NONE = 748895195U;
            } // namespace STATE
        } // namespace COMBAT

        namespace LEVEL
        {
            static const AkUniqueID GROUP = 2782712965U;

            namespace STATE
            {
                static const AkUniqueID CITY_1 = 1707324172U;
                static const AkUniqueID CITY_2 = 1707324175U;
                static const AkUniqueID CITY_3 = 1707324174U;
                static const AkUniqueID LAB = 578926554U;
                static const AkUniqueID MAYOR_ROOM = 3105353467U;
                static const AkUniqueID NONE = 748895195U;
                static const AkUniqueID PHIL_ROOM = 2552669160U;
                static const AkUniqueID STARTUP = 2530218128U;
                static const AkUniqueID THE_HUB = 1036396546U;
            } // namespace STATE
        } // namespace LEVEL

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

        namespace WEAPON
        {
            static const AkUniqueID GROUP = 3893417221U;

            namespace SWITCH
            {
                static const AkUniqueID DEFAULT = 782826392U;
                static const AkUniqueID MAYOR_WEAPON = 3027089830U;
                static const AkUniqueID PHIL_WEAPON = 756542853U;
            } // namespace SWITCH
        } // namespace WEAPON

    } // namespace SWITCHES

    namespace GAME_PARAMETERS
    {
        static const AkUniqueID DISTANCE_BUREAUCRAT = 1011057461U;
        static const AkUniqueID DISTANCE_CHIEF = 2867040294U;
        static const AkUniqueID DISTANCE_MAYOR = 4111688057U;
        static const AkUniqueID DISTANCE_MONEY = 263702421U;
        static const AkUniqueID DISTANCE_ORGANIZER = 3507896190U;
        static const AkUniqueID DISTANCE_PHILANTHROPIST = 560269304U;
        static const AkUniqueID DISTANCE_REBEL = 819496709U;
        static const AkUniqueID HEALTH = 3677180323U;
    } // namespace GAME_PARAMETERS

    namespace BANKS
    {
        static const AkUniqueID INIT = 1355168291U;
        static const AkUniqueID ENEMIES = 2242381963U;
        static const AkUniqueID MUSIC_AND_AMBIENCE = 115247927U;
        static const AkUniqueID PHILANTHROPIST = 204495494U;
        static const AkUniqueID THE_MAYOR = 80144099U;
        static const AkUniqueID UNCOVERED_SOUNDBANK = 965033712U;
    } // namespace BANKS

    namespace BUSSES
    {
        static const AkUniqueID AMBIENCE = 85412153U;
        static const AkUniqueID BOSS = 1560169506U;
        static const AkUniqueID MASTER_AUDIO_BUS = 3803692087U;
        static const AkUniqueID MUSIC = 3991942870U;
        static const AkUniqueID PLAYER = 1069431850U;
        static const AkUniqueID SFX = 393239870U;
    } // namespace BUSSES

    namespace AUDIO_DEVICES
    {
        static const AkUniqueID NO_OUTPUT = 2317455096U;
        static const AkUniqueID SYSTEM = 3859886410U;
    } // namespace AUDIO_DEVICES

}// namespace AK

#endif // __WWISE_IDS_H__
