﻿using System.Linq;
using System.Text;
using System.Windows.Forms;
using Zony.Lib.Infrastructures.Dependency;
using Zony.Lib.Infrastructures.EventBus;
using Zony.Lib.Infrastructures.EventBus.Handlers;
using Zony.Lib.Plugin.Common;
using Zony.Lib.Plugin.Common.Extensions;
using Zony.Lib.Plugin.Enums;
using ZonyLrcTools.Common;

namespace ZonyLrcTools.Events.UIEvents
{
    public class UIComponentDownloadCompleteEventData : EventData
    {

    }

    public class UIComponentDownloadCompleteEvent : IEventHandler<UIComponentDownloadCompleteEventData>, ITransientDependency
    {
        public void HandleEvent(UIComponentDownloadCompleteEventData eventData)
        {
            GlobalContext.Instance.SetBottomStatusText(AppConsts.Status_Bottom_DownloadComplete);

            // 构建成功文本
            StringBuilder builder = new StringBuilder();
            builder.Append("下载成功，状态如下:\n");
            builder.Append($"成功:{GlobalContext.Instance.MusicInfos.Count(z => z.Status == MusicInfoEnum.Success)}\n");
            builder.Append($"失败:{GlobalContext.Instance.MusicInfos.Count(z => z.Status == MusicInfoEnum.Failed)}\n");
            builder.Append($"未找到:{GlobalContext.Instance.MusicInfos.Count(z => z.Status == MusicInfoEnum.NotFound)}\n");
            builder.Append($"略过:{GlobalContext.Instance.MusicInfos.Count(z => z.Status == MusicInfoEnum.Ignore)}\n");
            builder.Append($"服务限制:{GlobalContext.Instance.MusicInfos.Count(z => z.Status == MusicInfoEnum.Unavailable)}");
            builder.Append($"代理服务器异常:{GlobalContext.Instance.MusicInfos.Count(z => z.Status == MusicInfoEnum.ProxyException)}");

            MessageBox.Show(builder.ToString(), "完成", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
