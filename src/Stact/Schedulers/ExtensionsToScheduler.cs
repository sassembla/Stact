// Copyright 2010 Chris Patterson
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
namespace Stact
{
	using System;
	using Internal;
	using Magnum.Extensions;


	public static class ExtensionsToScheduler
	{
		/// <summary>
		/// Schedules an operation to be executed after the special interval has elapsed
		/// </summary>
		/// <param name="scheduler">The scheduler to reference</param>
		/// <param name="interval">The duration of the interval</param>
		/// <param name="fiber">The fiber where the operation should be added</param>
		/// <param name="operation">The operation to execute</param>
		/// <returns>A ScheduledOperation reference</returns>
		public static ScheduledOperation Schedule(this Scheduler scheduler, int interval, Fiber fiber, Action operation)
		{
			return scheduler.Schedule(interval.Milliseconds(), fiber, operation);
		}

		/// <summary>
		/// Schedules an operation to be executed after the special interval has elapsed and
		/// every periodic interval after the initial execution
		/// </summary>
		/// <param name="scheduler">The scheduler to reference</param>
		/// <param name="interval">The duration of the interval</param>
		/// <param name="periodicInterval">The periodic interval between subsequent executions</param>
		/// <param name="fiber">The fiber where the operation should be added</param>
		/// <param name="operation">The operation to execute</param>
		/// <returns>A ScheduledOperation reference</returns>
		public static ScheduledOperation Schedule(this Scheduler scheduler, int interval, int periodicInterval, Fiber fiber,
		                                          Action operation)
		{
			return scheduler.Schedule(interval.Milliseconds(), periodicInterval.Milliseconds(), fiber, operation);
		}

		public static IDisposable ShutdownOnDispose(this Scheduler scheduler, TimeSpan timeout)
		{
			return new ShutdownSchedulerOnDispose(scheduler, timeout);
		}

	}
}