// Decompiled with JetBrains decompiler
// Type: Amplitude.Mercury.Interop.EditorOrderForceGainMoral
// Assembly: Amplitude.Mercury.Firstpass, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C6020605-CF00-449D-A856-BC7A2B6C1CDA
// Assembly location: C:\HUMANKIND\Humankind_Data\Managed\Amplitude.Mercury.Firstpass.dll

using Amplitude.IO;
using Amplitude.Serialization;

namespace Amplitude.Mercury.Interop
{
  public class EditorOrderForceGainMoral : EditorOrder
  {
    public int Gain;
    public int MajorEmpireIndex;
    public int OtherEmpireIndex;

    public override OrderIdentifier OrderIdentifier => OrderIdentifier.EditorOrderForceGainMoral;

    public override void Pack(BinaryMemoryStream writer)
    {
      base.Pack(writer);
      writer.Write(this.MajorEmpireIndex);
      writer.Write(this.OtherEmpireIndex);
      writer.Write(this.Gain);
    }

    public override void Unpack(BinaryMemoryStream reader)
    {
      base.Unpack(reader);
      this.OtherEmpireIndex = reader.ReadInt32();
      this.MajorEmpireIndex = reader.ReadInt32();
      this.Gain = reader.ReadInt32();
    }

    public override void Serialize(Serializer serializer)
    {
      this.MajorEmpireIndex = serializer.SerializeElement("MajorEmpire", this.MajorEmpireIndex);
      this.OtherEmpireIndex = serializer.SerializeElement("OtherEmpireIndex", this.OtherEmpireIndex);
      this.Gain = serializer.SerializeElement("Gain", this.Gain);
    }

    internal override bool TryResolveEmpireIndexes(EditorOrdersEmpireIndexResolver resolver) => resolver.TryResolveEmpireIndex(ref this.MajorEmpireIndex);
  }
}
