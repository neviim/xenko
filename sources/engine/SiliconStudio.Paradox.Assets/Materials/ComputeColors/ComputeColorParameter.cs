﻿// Copyright (c) 2014 Silicon Studio Corp. (http://siliconstudio.co.jp)
// This file is distributed under GPL v3. See LICENSE.md for details.

using System.ComponentModel;

using SiliconStudio.Core;
using SiliconStudio.Core.Mathematics;
using SiliconStudio.Paradox.Graphics;

namespace SiliconStudio.Paradox.Assets.Materials.ComputeColors
{
    /// <summary>
    /// Base class for a Color compute color parameter.
    /// </summary>
    [DataContract("ComputeColorParameter")]
    public abstract class ComputeColorParameter : IComputeColorParameter
    {
    }

    [DataContract("ComputeColorParameterTexture")]
    public class ComputeColorParameterTexture : ComputeColorParameter
    {
        public ComputeColorParameterTexture()
        {
            Texture = new ComputeTextureColor();
        }

        public ComputeTextureColor Texture { get; private set; }
    }

    [DataContract()]
    public abstract class ComputeColorParameterValue<T> : IComputeColorParameter
    {
        [DataMember(10)]
        public T Value { get; set; }
    }

    [DataContract("ComputeColorStringParameter")]
    public class ComputeColorStringParameter : ComputeColorParameterValue<string>
    {
        public ComputeColorStringParameter()
            : base()
        {
            Value = string.Empty;
        }
    }

    [DataContract("ComputeColorParameterFloat")]
    public class ComputeColorParameterFloat : ComputeColorParameterValue<float>
    {
        public ComputeColorParameterFloat()
            : base()
        {
            Value = 0.0f;
        }
    }

    [DataContract("ComputeColorParameterInt")]
    public class ComputeColorParameterInt : ComputeColorParameterValue<int>
    {
        public ComputeColorParameterInt()
            : base()
        {
            Value = 0;
        }
    }

    [DataContract("ComputeColorParameterFloat2")]
    public class ComputeColorParameterFloat2 : ComputeColorParameterValue<Vector2>
    {
        public ComputeColorParameterFloat2()
            : base()
        {
            Value = Vector2.Zero;
        }
    }

    [DataContract("ComputeColorParameterFloat3")]
    public class ComputeColorParameterFloat3 : ComputeColorParameterValue<Vector3>
    {
        public ComputeColorParameterFloat3()
            : base()
        {
            Value = Vector3.Zero;
        }
    }

    [DataContract("ComputeColorParameterFloat4")]
    public class ComputeColorParameterFloat4 : ComputeColorParameterValue<Vector4>
    {
        public ComputeColorParameterFloat4()
            : base()
        {
            Value = Vector4.Zero;
        }
    }

    [DataContract("ComputeColorParameterSampler")]
    public class ComputeColorParameterSampler : IComputeColorParameter
    {
        /// <summary>
        /// The texture filtering mode.
        /// </summary>
        [DataMember(10)]
        [DefaultValue(TextureFilter.Linear)]
        public TextureFilter Filtering { get; set; }

        /// <summary>
        /// The texture address mode.
        /// </summary>
        [DataMember(20)]
        [DefaultValue(TextureAddressMode.Wrap)]
        public TextureAddressMode AddressModeU { get; set; }

        /// <summary>
        /// The texture address mode.
        /// </summary>
        [DataMember(30)]
        [DefaultValue(TextureAddressMode.Wrap)]
        public TextureAddressMode AddressModeV { get; set; }

        public ComputeColorParameterSampler()
        {
            Filtering = TextureFilter.Linear;
            AddressModeU = TextureAddressMode.Wrap;
            AddressModeV = TextureAddressMode.Wrap;
        }
    }
}
