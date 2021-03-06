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
namespace Stact.Internal
{
	using System;


	public class ShutdownSchedulerOnDispose :
		IDisposable
	{
		readonly Scheduler _scheduler;
		TimeSpan _timeout;

		public ShutdownSchedulerOnDispose(Scheduler scheduler, TimeSpan timeout)
		{
			_scheduler = scheduler;
			_timeout = timeout;
		}

		public void Dispose()
		{
			_scheduler.Stop(_timeout);
		}
	}
}