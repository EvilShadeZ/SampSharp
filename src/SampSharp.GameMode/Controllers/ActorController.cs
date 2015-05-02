﻿// SampSharp
// Copyright 2015 Tim Potze
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using System;
using SampSharp.GameMode.World;

namespace SampSharp.GameMode.Controllers
{
    /// <summary>
    ///     A controller processing all actor actions.
    /// </summary>
    public class ActorController : ITypeProvider, IEventListener
    {
        #region Implementation of IEventListener

        /// <summary>
        ///     Registers the events this <see cref="IEventListener" /> wants to listen to.
        /// </summary>
        /// <param name="gameMode">An instance of the <see cref="BaseMode" /> currently running.</param>
        public void RegisterEvents(BaseMode gameMode)
        {
            gameMode.PlayerGiveDamageActor += (sender, args) =>
            {
                var actor = sender as Actor;
                if (actor != null)
                    actor.OnPlayerGiveDamage(args);
            };
            gameMode.ActorStreamIn += (sender, args) =>
            {
                var actor = sender as Actor;
                if (actor != null)
                    actor.OnStreamIn(args);
            };
            gameMode.ActorStreamOut += (sender, args) =>
            {
                var actor = sender as Actor;
                if (actor != null)
                    actor.OnStreamOut(args);
            };
        }

        #endregion

        #region Implementation of ITypeProvider

        /// <summary>
        ///     Registers types this <see cref="ITypeProvider" /> requires the system to use.
        /// </summary>
        public void RegisterTypes()
        {
            Actor.Register<Actor>();
        }

        #endregion
    }
}