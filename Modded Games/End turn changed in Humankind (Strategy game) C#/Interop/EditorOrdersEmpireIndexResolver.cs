// Decompiled with JetBrains decompiler
// Type: Amplitude.Mercury.Interop.EditorOrdersEmpireIndexResolver
// Assembly: Amplitude.Mercury.Firstpass, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C6020605-CF00-449D-A856-BC7A2B6C1CDA
// Assembly location: C:\HUMANKIND\Humankind_Data\Managed\Amplitude.Mercury.Firstpass.dll

using Amplitude.Mercury.Data.Scenario;
using Amplitude.Serialization;
using System;

namespace Amplitude.Mercury.Interop
{
  public class EditorOrdersEmpireIndexResolver : ISerializable
  {
    private string[] serializedEmpireUniqueIdentifiers;
    private int serializedLesserEmpireIndex;
    private int[] majorEmpireNewIndexes;
    private int minorEmpireIndexOffset;
    private int oldLesserEmpireIndex;
    private int newLesserEmpireIndex;

    public string[] EmpireUniqueIdentifiers => this.serializedEmpireUniqueIdentifiers;

    public bool IsValid => this.majorEmpireNewIndexes != null;

    public void Initialize(GameScenarioDefinition scenarioDefinition, int newLesserEmpireIndex)
    {
      int length1 = this.serializedEmpireUniqueIdentifiers != null ? this.serializedEmpireUniqueIdentifiers.Length : 0;
      int length2 = scenarioDefinition.MajorEmpires != null ? scenarioDefinition.MajorEmpires.Length : 0;
      if (length1 > 0)
      {
        this.majorEmpireNewIndexes = new int[length1];
        for (int index = 0; index < length1; ++index)
          this.majorEmpireNewIndexes[index] = -1;
        for (int index1 = 0; index1 < length2; ++index1)
        {
          int index2 = Array.IndexOf<string>(this.serializedEmpireUniqueIdentifiers, scenarioDefinition.MajorEmpires[index1].UniqueIdentifier);
          if (index2 >= 0)
            this.majorEmpireNewIndexes[index2] = index1;
        }
        this.minorEmpireIndexOffset = length2 - length1;
        this.oldLesserEmpireIndex = this.serializedLesserEmpireIndex;
        this.newLesserEmpireIndex = newLesserEmpireIndex;
      }
      this.serializedEmpireUniqueIdentifiers = new string[length2];
      for (int index = 0; index < length2; ++index)
      {
        MajorEmpireDefinition majorEmpire = scenarioDefinition.MajorEmpires[index];
        this.serializedEmpireUniqueIdentifiers[index] = majorEmpire.UniqueIdentifier;
      }
      this.serializedLesserEmpireIndex = newLesserEmpireIndex;
    }

    public bool TryResolveEmpireIndex(ref int empireIndex)
    {
      int length = this.majorEmpireNewIndexes.Length;
      if (empireIndex < length)
        empireIndex = this.majorEmpireNewIndexes[empireIndex];
      else if (empireIndex == this.oldLesserEmpireIndex)
      {
        empireIndex = this.newLesserEmpireIndex;
      }
      else
      {
        empireIndex += this.minorEmpireIndexOffset;
        if (empireIndex >= this.newLesserEmpireIndex)
          empireIndex = -1;
      }
      return empireIndex >= 0;
    }

    public void Serialize(Serializer serializer)
    {
      this.serializedEmpireUniqueIdentifiers = serializer.SerializeElement("EmpireUniqueIdentifiers", this.serializedEmpireUniqueIdentifiers);
      this.serializedLesserEmpireIndex = serializer.SerializeElement("LesserEmpireIndex", this.serializedLesserEmpireIndex);
    }
  }
}
