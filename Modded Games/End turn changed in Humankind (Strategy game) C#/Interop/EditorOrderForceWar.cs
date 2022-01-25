// Decompiled with JetBrains decompiler
// Type: Amplitude.Mercury.Interop.EditorOrderForceWar
// Assembly: Amplitude.Mercury.Firstpass, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C6020605-CF00-449D-A856-BC7A2B6C1CDA
// Assembly location: C:\HUMANKIND\Humankind_Data\Managed\Amplitude.Mercury.Firstpass.dll

using Amplitude.IO;
using Amplitude.Serialization;

namespace Amplitude.Mercury.Interop
{
  [Revision(1, "[FM][2020-02-26] Fix serialization element name.", "D:\\junctions\\sFVM-o2y\\0\\HG\\Development\\Unity Projects\\Amplitude.Mercury.Unityproject\\Assets\\Plugins\\Amplitude.Mercury.Interop\\Orders\\Editors\\EditorOrderForceWar.cs")]
  public class EditorOrderForceWar : EditorOrder
  {
    public int LeftEmpireIndex = -1;
    public int RightEmpireIndex = -1;

    public override OrderIdentifier OrderIdentifier => OrderIdentifier.EditorOrderForceWar;

    public override void Pack(BinaryMemoryStream writer)
    {
      base.Pack(writer);
      writer.Write(this.LeftEmpireIndex);
      writer.Write(this.RightEmpireIndex);
    }

    public override void Unpack(BinaryMemoryStream reader)
    {
      base.Unpack(reader);
      this.LeftEmpireIndex = reader.ReadInt32();
      this.RightEmpireIndex = reader.ReadInt32();
    }

    public override void Serialize(Serializer serializer)
    {
      if (serializer.SerializeRevision(nameof (Serialize), "D:\\junctions\\sFVM-o2y\\0\\HG\\Development\\Unity Projects\\Amplitude.Mercury.Unityproject\\Assets\\Plugins\\Amplitude.Mercury.Interop\\Orders\\Editors\\EditorOrderForceWar.cs", 38) >= 1)
      {
        this.LeftEmpireIndex = serializer.SerializeElement("LeftEmpireIndex", this.LeftEmpireIndex);
        this.RightEmpireIndex = serializer.SerializeElement("RightEmpireIndex", this.RightEmpireIndex);
      }
      else
      {
        this.LeftEmpireIndex = serializer.SerializeElement("EmpireIndex", this.LeftEmpireIndex);
        this.RightEmpireIndex = serializer.SerializeElement("ChoiceIndex", this.RightEmpireIndex);
      }
    }

    internal override bool TryResolveEmpireIndexes(EditorOrdersEmpireIndexResolver resolver) => resolver.TryResolveEmpireIndex(ref this.LeftEmpireIndex) && resolver.TryResolveEmpireIndex(ref this.RightEmpireIndex);
  }
}
