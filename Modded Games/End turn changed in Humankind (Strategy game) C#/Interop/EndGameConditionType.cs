// Decompiled with JetBrains decompiler
// Type: Amplitude.Mercury.Interop.EndGameConditionType
// Assembly: Amplitude.Mercury.Firstpass, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C6020605-CF00-449D-A856-BC7A2B6C1CDA
// Assembly location: C:\HUMANKIND\Humankind_Data\Managed\Amplitude.Mercury.Firstpass.dll

using Amplitude.UI;

namespace Amplitude.Mercury.Interop
{
  [CanGenerateUIMapper(UIMapperType = "EndGameConditionUIMapper")]
  public enum EndGameConditionType
  {
    [ExcludeFromUIMapperGeneration] None,
    AllEmpireVassalized,
    AllResearchesDone,
    BattleWon,
    DeedAccomplished,
    EmpireEliminated,
    EraLimit,
    PathCuriosity,
    SpecificDiplomaticRelation,

    ValueThreshold,
    WarWon,
    EveryoneIsDead,
    SpaceRace,
    Pollution,
    Cheat,
  }
}
