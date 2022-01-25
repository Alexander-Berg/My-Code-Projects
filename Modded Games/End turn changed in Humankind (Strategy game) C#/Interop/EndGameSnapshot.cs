// Decompiled with JetBrains decompiler
// Type: Amplitude.Mercury.Interop.EndGameSnapshot
// Assembly: Amplitude.Mercury.Firstpass, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C6020605-CF00-449D-A856-BC7A2B6C1CDA
// Assembly location: C:\HUMANKIND\Humankind_Data\Managed\Amplitude.Mercury.Firstpass.dll

using Amplitude.Mercury.Sandbox;
using Amplitude.Mercury.Simulation;

namespace Amplitude.Mercury.Interop
{
  public class EndGameSnapshot : Snapshot<EndGameSnapshot.Data>
  {
    protected override void InitializeOnLoad(EndGameSnapshot.Data[] dataArray)
    {
      base.InitializeOnLoad(dataArray);
      int numberOfMajorEmpires = Amplitude.Mercury.Sandbox.Sandbox.NumberOfMajorEmpires;
      for (int index = 0; index < dataArray.Length; ++index)
      {
        EndGameSnapshot.Data data = dataArray[index];
        data.EndGameStatus = EndGameStatus.NotEnded;
        data.WaitingForContinueEmpireBits = 0;
        data.CivilizationInfoPerEmpireIndex = new CivilizationInfo[numberOfMajorEmpires];
        data.FinalFamePerEmpireIndex = new FixedPoint[numberOfMajorEmpires];
        data.RankedEmpireIndexes = new int[Amplitude.Mercury.Sandbox.Sandbox.NumberOfMajorEmpires];
      }
      this.Start();
    }

    protected override bool Synchronize(EndGameSnapshot.Data simulationData, int frame)
    {
      bool flag1 = false;
      EndGameSnapshot.Data presentationData = this.PresentationData;
      int num = 0;
      EndGameConditionType gameConditionType = Amplitude.Mercury.Sandbox.Sandbox.EndGameController.EndGameConditionType;
      EndGameStatus endGameStatus = Amplitude.Mercury.Sandbox.Sandbox.EndGameController.EndGameStatus;
      StaticString name = Amplitude.Mercury.Sandbox.Sandbox.EndGameController.EndGameDefinition.Name;
      bool flag2 = flag1 | presentationData.EndGameStatus != endGameStatus | presentationData.EndGameConditionDefinitionName != name | presentationData.WaitingForContinueEmpireBits != num | presentationData.EndGameContitionType != gameConditionType | simulationData.TurnLimit != Amplitude.Mercury.Sandbox.Sandbox.EndGameController.TurnLimit | presentationData.PlayerEmpireIndex != SandboxManager.Sandbox.LocalEmpireIndex | presentationData.StartingEraIndex != Amplitude.Mercury.Sandbox.Sandbox.Timeline.StartingEraIndex | presentationData.EndingEraIndex != Amplitude.Mercury.Sandbox.Sandbox.Timeline.EndingEraIndex;
      int numberOfMajorEmpires = Amplitude.Mercury.Sandbox.Sandbox.NumberOfMajorEmpires;
      for (int index = 0; index < numberOfMajorEmpires; ++index)
      {
        MajorEmpire majorEmpire = Amplitude.Mercury.Sandbox.Sandbox.MajorEmpires[index];
        flag2 = flag2 | presentationData.CivilizationInfoPerEmpireIndex[index].Frame < majorEmpire.CivilizationInfo.Frame | presentationData.FinalFamePerEmpireIndex[index] != majorEmpire.FameScore.Value;
      }
      if (!flag2)
        return false;
      simulationData.EndGameStatus = endGameStatus;
      simulationData.EndGameContitionType = gameConditionType;
      simulationData.EndGameConditionDefinitionName = name;
      simulationData.TurnLimit = Amplitude.Mercury.Sandbox.Sandbox.EndGameController.TurnLimit;
      simulationData.IsInPostEndGame = Amplitude.Mercury.Sandbox.Sandbox.EndGameController.IsInPostEndGame;
      if (endGameStatus == EndGameStatus.NotEnded || endGameStatus == EndGameStatus.LastTurn)
        return true;
      simulationData.WaitingForContinueEmpireBits = num;
      simulationData.PlayerEmpireIndex = SandboxManager.Sandbox.LocalEmpireIndex;
      simulationData.StartingEraIndex = Amplitude.Mercury.Sandbox.Sandbox.Timeline.StartingEraIndex;
      simulationData.EndingEraIndex = Amplitude.Mercury.Sandbox.Sandbox.Timeline.EndingEraIndex;
      for (int index = 0; index < numberOfMajorEmpires; ++index)
      {
        MajorEmpire majorEmpire = Amplitude.Mercury.Sandbox.Sandbox.MajorEmpires[index];
        simulationData.CivilizationInfoPerEmpireIndex[index].CopyFrom(majorEmpire.CivilizationInfo);
        simulationData.FinalFamePerEmpireIndex[index] = majorEmpire.FameScore.Value;
      }
      if (endGameStatus == EndGameStatus.EndGame)
        Amplitude.Mercury.Sandbox.Sandbox.FameRankingController.FillCurrentEmpireRankings(simulationData.RankedEmpireIndexes);
      return true;
    }

    public new class Data : Snapshot.Data
    {
      public EndGameStatus EndGameStatus;
      public int WaitingForContinueEmpireBits;
      public EndGameConditionType EndGameContitionType;
      public StaticString EndGameConditionDefinitionName;
      public int TurnLimit;
      public bool IsInPostEndGame;
      public int PlayerEmpireIndex;
      public int StartingEraIndex;
      public int EndingEraIndex;
      public int[] RankedEmpireIndexes;
      public CivilizationInfo[] CivilizationInfoPerEmpireIndex;
      public FixedPoint[] FinalFamePerEmpireIndex;
    }
  }
}
