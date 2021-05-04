using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using SimpleGltf.Enums;
using SimpleGltf.Json.Extensions;

namespace SimpleGltf.Json
{
    public class BufferView
    {
        internal readonly Buffer Buffer;
        internal readonly GltfAsset GltfAsset;

        internal BufferView(GltfAsset gltfAsset, Buffer buffer, BufferViewTarget target, string name)
        {
            GltfAsset = gltfAsset;
            GltfAsset.BufferViews ??= new List<BufferView>();
            GltfAsset.BufferViews.Add(this);
            Buffer = buffer;
            Target = target;
            Name = name;
        }

        [JsonPropertyName("buffer")] public int BufferReference => GltfAsset.Buffers.IndexOf(Buffer);

        public int? ByteOffset => this.GetByteOffset();

        public int ByteLength => (int) this.GetAccessors().GetLength();

        public int? ByteStride
        {
            get
            {
                if (Target == BufferViewTarget.ElementArrayBuffer)
                    return null;
                var accessors = this.GetAccessors().ToList();
                return accessors.Count == 1 ? null : accessors.GetStride();
            }
        }

        public BufferViewTarget Target { get; }

        public string Name { get; }
    }
}