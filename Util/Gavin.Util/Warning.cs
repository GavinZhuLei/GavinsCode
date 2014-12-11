﻿using System.Collections;
using Gavin.Util.Logs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gavin.Util
{
    public class Warning:Exception
    {
        #region 构造方法

        /// <summary>
        /// 初始化应用程序异常
        /// </summary>
        /// <param name="message">错误消息</param>
        public Warning(string message)
            : this(message, "")
        {
        }

        /// <summary>
        /// 初始化应用程序异常
        /// </summary>
        /// <param name="message">错误消息</param>
        /// <param name="code">错误码</param>
        public Warning(string message, string code)
            : this(message, code, LogLevel.Warning)
        {
        }

        /// <summary>
        /// 初始化应用程序异常
        /// </summary>
        /// <param name="message">错误消息</param>
        /// <param name="code">错误码</param>
        /// <param name="level">日志级别</param>
        public Warning(string message, string code, LogLevel level)
            : this(message, code, level, null)
        {
        }

        /// <summary>
        /// 初始化应用程序异常
        /// </summary>
        /// <param name="exception">异常</param>
        public Warning(Exception exception)
            : this("", "", LogLevel.Warning, exception)
        {
        }

        /// <summary>
        /// 初始化应用程序异常
        /// </summary>
        /// <param name="message">错误消息</param>
        /// <param name="code">错误码</param>
        /// <param name="exception">异常</param>
        public Warning(string message, string code, Exception exception)
            : this(message, code, LogLevel.Warning, exception)
        {
        }

        /// <summary>
        /// 初始化应用程序异常
        /// </summary>
        /// <param name="message">错误消息</param>
        /// <param name="code">错误码</param>
        /// <param name="level">日志级别</param>
        /// <param name="exception">异常</param>
        public Warning(string message, string code, LogLevel level, Exception exception)
            : base(message ?? "", exception)
        {
            Code = code;
            Level = level;
            _message = GetMessage();
        }

        /// <summary>
        /// 获取错误消息
        /// </summary>
        private string GetMessage()
        {
            var result = new StringBuilder();
            AppendSelfMessage(result);
            AppendInnerMessage(result, InnerException);
            return result.ToString().TrimEnd(Environment.NewLine.ToCharArray());
        }

        /// <summary>
        /// 添加本身消息
        /// </summary>
        private void AppendSelfMessage(StringBuilder result)
        {
            if (string.IsNullOrWhiteSpace(base.Message))
                return;
            result.AppendLine(base.Message);
        }

        /// <summary>
        /// 添加内部异常消息
        /// </summary>
        private void AppendInnerMessage(StringBuilder result, Exception exception)
        {
            if (exception == null)
                return;
            if (exception is Warning)
            {
                result.AppendLine(exception.Message);
                return;
            }
            result.AppendLine(exception.Message);
            result.Append(GetData(exception));
            AppendInnerMessage(result, exception.InnerException);
        }

        /// <summary>
        /// 获取添加的额外数据
        /// </summary>
        private string GetData(Exception ex)
        {
            var result = new StringBuilder();
            foreach (DictionaryEntry data in ex.Data)
                result.AppendFormat("{0}:{1}{2}", data.Key, data.Value, Environment.NewLine);
            return result.ToString();
        }

        #endregion

        #region Message(错误消息)

        /// <summary>
        /// 错误消息
        /// </summary>
        private readonly string _message;

        /// <summary>
        /// 错误消息
        /// </summary>
        public override string Message
        {
            get
            {
                if (Data.Count == 0)
                    return _message;
                return _message + Environment.NewLine + GetData(this);
            }
        }

        #endregion

        #region TraceId(跟踪号)

        /// <summary>
        /// 跟踪号
        /// </summary>
        public string TraceId { get; set; }

        #endregion

        #region Code(错误码)

        /// <summary>
        /// 错误码
        /// </summary>
        public string Code { get; set; }

        #endregion

        #region Level(日志级别)

        /// <summary>
        /// 日志级别
        /// </summary>
        public LogLevel Level { get; set; }

        #endregion

        #region StackTrace(堆栈跟踪)

        /// <summary>
        /// 堆栈跟踪
        /// </summary>
        public override string StackTrace
        {
            get
            {
                if (!string.IsNullOrWhiteSpace(base.StackTrace))
                    return base.StackTrace;
                if (base.InnerException == null)
                    return string.Empty;
                return base.InnerException.StackTrace;
            }
        }

        #endregion
    }
}
