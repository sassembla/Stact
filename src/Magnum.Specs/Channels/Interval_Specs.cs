// Copyright 2007-2008 The Apache Software Foundation.
//  
// Licensed under the Apache License, Version 2.0 (the "License"); you may not use 
// this file except in compliance with the License. You may obtain a copy of the 
// License at 
// 
//     http://www.apache.org/licenses/LICENSE-2.0 
// 
// Unless required by applicable law or agreed to in writing, software distributed 
// under the License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR 
// CONDITIONS OF ANY KIND, either express or implied. See the License for the 
// specific language governing permissions and limitations under the License.
namespace Magnum.Specs.Channels
{
	using System.Collections.Generic;
	using DateTimeExtensions;
	using Magnum.Actions;
	using Magnum.Actors;
	using Magnum.Channels;
	using NUnit.Framework;
	using TestFramework;

	[TestFixture]
	public class Sending_to_an_interval_subscriber
	{
		[Test]
		public void Should_deliver_the_messages_at_once()
		{
			var queue = new SynchronousActionQueue();
			var scheduler = new TimerActionScheduler();

			var called = new Future<IList<MyMessage>>();
			var channel = new IntervalConsumerChannel<MyMessage>(queue, scheduler, 1.Seconds(), called.Complete);

			for (int i = 0; i < 5; i++)
			{
				channel.Send(new MyMessage());
			}

			called.IsAvailable(2.Seconds()).ShouldBeTrue();

			channel.Dispose();

			called.Value.ShouldNotBeNull();
			called.Value.Count.ShouldEqual(5);
		}
	}
}