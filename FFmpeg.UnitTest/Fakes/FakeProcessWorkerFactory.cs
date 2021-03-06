﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using HanumanInstitute.FFmpeg.Services;
using Moq;

namespace HanumanInstitute.FFmpeg.UnitTests
{
    public class FakeProcessWorkerFactory : ProcessWorkerFactory
    {

        public FakeProcessWorkerFactory() : base(new FakeMediaConfig(), null, new FileInfoParserFactory(), new FakeProcessFactory(), new FakeFileSystemService())
        {
        }

        /// <summary>
        /// Returns the list of instances that were created by the factory.
        /// </summary>
        public List<IProcessWorker> Instances { get; private set; } = new List<IProcessWorker>();

        public override IProcessWorker Create(object owner, ProcessOptions options = null, ProcessStartedEventHandler callback = null)
        {
            var result = base.Create(owner, options, callback);
            Instances.Add(result);
            return result;
        }

        public override IProcessWorkerEncoder CreateEncoder(object owner, ProcessOptionsEncoder options = null, ProcessStartedEventHandler callback = null)
        {
            var result = base.CreateEncoder(owner, options, callback);
            result.ProcessCompleted += (s, e) =>
            {
                if (result.FileInfo is FileInfoFFmpeg info && info.FileStreams == null)
                {
                    // If no data was fed into the process, this will initialize FileStreams.
                    var mockP = Mock.Get<IProcess>(result.WorkProcess);
                    mockP.Raise(x => x.ErrorDataReceived += null, CreateMockDataReceivedEventArgs(null));
                    mockP.Raise(x => x.OutputDataReceived += null, CreateMockDataReceivedEventArgs(null));
                    if (info.FileStreams != null)
                    {
                        info.FileStreams.Add(new MediaVideoStreamInfo());
                        info.FileStreams.Add(new MediaAudioStreamInfo());
                    }
                }
            };
            Instances.Add(result);
            return result;
        }

        /// <summary>
        /// Feeds a sample output into a mock process.
        /// </summary>
        /// <param name="p">The process manager to feed data into..</param>
        /// <param name="output">The sample output to feed.</param>
        public static void FeedOutputToProcess(IProcessWorker p, string output)
        {
            var mockP = Mock.Get<IProcess>(p.WorkProcess);
            using (var sr = new StringReader(output))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    mockP.Raise(x => x.ErrorDataReceived += null, CreateMockDataReceivedEventArgs(line));
                }
            }
            mockP.Raise(x => x.ErrorDataReceived += null, CreateMockDataReceivedEventArgs(null));
        }

        /// <summary>
        /// Since DataReceivedEventArgs can't be directly created, create an instance through reflection.
        /// </summary>
        public static DataReceivedEventArgs CreateMockDataReceivedEventArgs(string testData)
        {
            var mockEventArgs =
                (DataReceivedEventArgs)System.Runtime.Serialization.FormatterServices
                 .GetUninitializedObject(typeof(DataReceivedEventArgs));

            var eventFields = typeof(DataReceivedEventArgs)
                .GetFields(
                    BindingFlags.NonPublic |
                    BindingFlags.Instance |
                    BindingFlags.DeclaredOnly);

            if (eventFields.Length > 0)
            {
                eventFields[0].SetValue(mockEventArgs, testData);
            }
            else
            {
                throw new ApplicationException("Failed to find _data field!");
            }

            return mockEventArgs;
        }
    }
}
