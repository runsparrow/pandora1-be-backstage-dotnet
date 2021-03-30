using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Reflection;
using System.Collections;

namespace MISApi.HttpClients.HttpModes.TreeMode.AntdTree
{
    /// <summary>
    /// 
    /// </summary>
    public class TreeViewBase<T> : TreeMode.TreeViewBase<T>
    {
        #region 定义 AntdTree 的 方法

        /// <summary>
        /// 
        /// </summary>
        /// <param name="rows"></param>
        /// <param name="config"></param>
        /// <returns></returns>
        public List<Child> ToTree(List<T> rows, Config<T> config)
        {
            List<Child> treeChildren = ToTree(
                    ConvertTo(rows, config)
                );
            FillTo(treeChildren, config);
            return treeChildren;
        }
        /// <summary>
        /// 将Entity集合转换成尚未建立树形关系的Child集合
        /// </summary>
        /// <param name="rows"></param>
        /// <param name="config"></param>
        /// <returns></returns>
        private List<Child> ConvertTo(List<T> rows, Config<T> config)
        {
            List<Child> childs = new List<Child>();
            try
            {
                foreach (T row in rows)
                {
                    Child child = new Child();
                    if (config.PropertyBind.Id != null)
                    {
                        if (row.GetType().GetProperty(config.PropertyBind.Id) == null)
                            child.Id = -1;
                        else
                            child.Id = (int)row.GetType().GetProperty(config.PropertyBind.Id).GetValue(row);
                    }
                    if (config.PropertyBind.Pid != null)
                    {
                        if (row.GetType().GetProperty(config.PropertyBind.Pid) == null)
                            child.Pid = -1;
                        else
                        {
                            if (row.GetType().GetProperty(config.PropertyBind.Pid).GetValue(row) != null)
                                child.Pid = (int)row.GetType().GetProperty(config.PropertyBind.Pid).GetValue(row);
                        }
                    }
                    if (config.PropertyBind.Key != null)
                    {
                        if (row.GetType().GetProperty(config.PropertyBind.Key) == null)
                            child.Key = config.PropertyBind.Key;
                        else
                        {
                            if (row.GetType().GetProperty(config.PropertyBind.Key).GetValue(row) != null)
                                child.Key = row.GetType().GetProperty(config.PropertyBind.Key).GetValue(row).ToString();
                        }
                    }
                    if (config.PropertyBind.Title != null)
                    {
                        if (row.GetType().GetProperty(config.PropertyBind.Title) == null)
                            child.Title = config.PropertyBind.Title;
                        else
                        {
                            if (row.GetType().GetProperty(config.PropertyBind.Title).GetValue(row) != null)
                                child.Title = row.GetType().GetProperty(config.PropertyBind.Title).GetValue(row).ToString();
                        }
                    }
                    //if (config.PropertyBind.Tooltip != null)
                    //{
                    //    if (row.GetType().GetProperty(config.PropertyBind.Tooltip) == null)
                    //        child.Tooltip = config.PropertyBind.Tooltip;
                    //    else
                    //    {
                    //        if (row.GetType().GetProperty(config.PropertyBind.Tooltip).GetValue(row) != null)
                    //            child.Tooltip = row.GetType().GetProperty(config.PropertyBind.Tooltip).GetValue(row).ToString();
                    //    }
                    //}
                    //if (config.PropertyBind.Icon != null)
                    //{
                    //    if (row.GetType().GetProperty(config.PropertyBind.Icon) == null)
                    //        child.Icon = config.PropertyBind.Icon;
                    //    else
                    //    {
                    //        if (row.GetType().GetProperty(config.PropertyBind.Icon).GetValue(row) != null)
                    //            child.Icon = row.GetType().GetProperty(config.PropertyBind.Icon).GetValue(row).ToString();
                    //    }
                    //}
                    //if (config.PropertyBind.SelectedIcon != null)
                    //{
                    //    if (row.GetType().GetProperty(config.PropertyBind.SelectedIcon) == null)
                    //        child.SelectedIcon = config.PropertyBind.SelectedIcon;
                    //    else
                    //    {
                    //        if (row.GetType().GetProperty(config.PropertyBind.SelectedIcon).GetValue(row) != null)
                    //            child.SelectedIcon = row.GetType().GetProperty(config.PropertyBind.SelectedIcon).GetValue(row).ToString();
                    //    }
                    //}
                    //if (config.PropertyBind.Color != null)
                    //{
                    //    if (row.GetType().GetProperty(config.PropertyBind.Color) == null)
                    //        child.Color = config.PropertyBind.Color;
                    //    else
                    //    {
                    //        if (row.GetType().GetProperty(config.PropertyBind.Color).GetValue(row) != null)
                    //            child.Color = row.GetType().GetProperty(config.PropertyBind.Color).GetValue(row).ToString();
                    //    }
                    //}
                    //if (config.PropertyBind.BackColor != null)
                    //{
                    //    if (row.GetType().GetProperty(config.PropertyBind.BackColor) == null)
                    //        child.BackColor = config.PropertyBind.BackColor;
                    //    else
                    //    {
                    //        if (row.GetType().GetProperty(config.PropertyBind.BackColor).GetValue(row) != null)
                    //            child.BackColor = row.GetType().GetProperty(config.PropertyBind.BackColor).GetValue(row).ToString();
                    //    }
                    //}
                    //if (config.PropertyBind.Href != null)
                    //{
                    //    if (row.GetType().GetProperty(config.PropertyBind.Href) == null)
                    //        child.Href = config.PropertyBind.Href;
                    //    else
                    //    {
                    //        if (row.GetType().GetProperty(config.PropertyBind.Href).GetValue(row) != null)
                    //            child.Href = row.GetType().GetProperty(config.PropertyBind.Href).GetValue(row).ToString();
                    //    }
                    //}
                    if (config.PropertyBind.Selectable != null)
                    {
                        if (row.GetType().GetProperty(config.PropertyBind.Selectable) == null)
                            child.Selectable = bool.Parse(config.PropertyBind.Selectable);
                        else
                            child.Selectable = (bool)row.GetType().GetProperty(config.PropertyBind.Selectable).GetValue(row);
                    }
                    if (config.PropertyBind.Disabled != null)
                    {
                        if (row.GetType().GetProperty(config.PropertyBind.Disabled) == null)
                            child.Disabled = bool.Parse(config.PropertyBind.Disabled);
                        else
                            child.Disabled = (bool)row.GetType().GetProperty(config.PropertyBind.Disabled).GetValue(row);
                    }
                    if (config.PropertyBind.Levels != null)
                    {
                        if (row.GetType().GetProperty(config.PropertyBind.Levels) == null)
                            child.Levels = int.Parse(config.PropertyBind.Levels);
                        else
                            child.Levels = (int)row.GetType().GetProperty(config.PropertyBind.Levels).GetValue(row);
                    }
                    //if (config.PropertyBind.PreventUnselect != null)
                    //{
                    //    if (row.GetType().GetProperty(config.PropertyBind.PreventUnselect) == null)
                    //        child.PreventUnselect = bool.Parse(config.PropertyBind.PreventUnselect);
                    //    else
                    //        child.PreventUnselect = (bool)row.GetType().GetProperty(config.PropertyBind.PreventUnselect).GetValue(row);
                    //}
                    //if (config.PropertyBind.AllowReselect != null)
                    //{
                    //    if (row.GetType().GetProperty(config.PropertyBind.AllowReselect) == null)
                    //        child.AllowReselect = bool.Parse(config.PropertyBind.AllowReselect);
                    //    else
                    //        child.AllowReselect = (bool)row.GetType().GetProperty(config.PropertyBind.AllowReselect).GetValue(row);
                    //}
                    //if (config.PropertyBind.HideCheckbox != null)
                    //{
                    //    if (row.GetType().GetProperty(config.PropertyBind.HideCheckbox) == null)
                    //        child.HideCheckbox = bool.Parse(config.PropertyBind.HideCheckbox);
                    //    else
                    //        child.HideCheckbox = (bool)row.GetType().GetProperty(config.PropertyBind.HideCheckbox).GetValue(row);
                    //}
                    //if (config.PropertyBind.State != null)
                    //{
                    //    child.State.Checked = config.PropertyBind.State.Checked;
                    //    child.State.Expanded = config.PropertyBind.State.Expanded;
                    //    child.State.Selected = config.PropertyBind.State.Selected;
                    //    child.State.Disabled = config.PropertyBind.State.Disabled;
                    //}
                    //if (config.CheckedRows != null)
                    //{
                    //    config.CheckedRows.ForEach(
                    //            checkedRow =>
                    //            {
                    //                if (row.GetType().GetProperty("Id").GetValue(row).ToString() == checkedRow.GetType().GetProperty("Id").GetValue(checkedRow).ToString())
                    //                {
                    //                    child.State.Checked = true;
                    //                }
                    //            }
                    //        );
                    //}
                    //if (config.ExpandedRows != null)
                    //{
                    //    config.ExpandedRows.ForEach(
                    //            checkedRow =>
                    //            {
                    //                if (row.GetType().GetProperty("Id").GetValue(row).ToString() == checkedRow.GetType().GetProperty("Id").GetValue(checkedRow).ToString())
                    //                {
                    //                    child.State.Expanded = true;
                    //                }
                    //            }
                    //        );
                    //}
                    //if (config.SelectedRows != null)
                    //{
                    //    config.SelectedRows.ForEach(
                    //            checkedRow =>
                    //            {
                    //                if (row.GetType().GetProperty("Id").GetValue(row).ToString() == checkedRow.GetType().GetProperty("Id").GetValue(checkedRow).ToString())
                    //                {
                    //                    child.State.Selected = true;
                    //                }
                    //            }
                    //        );
                    //}
                    //if (config.DisabledRows != null)
                    //{
                    //    config.DisabledRows.ForEach(
                    //            checkedRow =>
                    //            {
                    //                if (row.GetType().GetProperty("Id").GetValue(row).ToString() == checkedRow.GetType().GetProperty("Id").GetValue(checkedRow).ToString())
                    //                {
                    //                    child.State.Disabled = true;
                    //                }
                    //            }
                    //        );
                    //}
                    child.Row = row;

                    childs.Add(child);

                    foreach (ChildPropertyBind childPropertyBind in config.ChildPropertyBinds)
                    {
                        //反射创建List
                        IList childsT = MakeListOfType(Assembly.GetExecutingAssembly().GetType(childPropertyBind.ChildPropertyClass));
                        //为List赋值
                        childsT = (IList)row.GetType().GetProperty(childPropertyBind.ChildPropertyName).GetValue(row);
                        //循环进行配置
                        for (int i = 0; i < childsT.Count; i++)
                        {
                            Child childT = new Child();
                            if (childPropertyBind.Id != null)
                            {
                                if (childsT[i].GetType().GetProperty(childPropertyBind.Id) == null)
                                    childT.Id = int.Parse(childPropertyBind.Id);
                                else
                                    childT.Id = (int)childsT[i].GetType().GetProperty(childPropertyBind.Id).GetValue(childsT[i]);
                            }
                            if (childPropertyBind.Pid != null)
                            {
                                if (childsT[i].GetType().GetProperty(childPropertyBind.Pid) == null)
                                    childT.Pid = int.Parse(childPropertyBind.Pid);
                                else
                                    childT.Pid = (int)childsT[i].GetType().GetProperty(childPropertyBind.Pid).GetValue(childsT[i]);
                            }
                            if (childPropertyBind.Key != null)
                            {
                                if (childsT[i].GetType().GetProperty(childPropertyBind.Key) == null)
                                    childT.Key = childPropertyBind.Key;
                                else
                                {
                                    if (childsT[i].GetType().GetProperty(childPropertyBind.Key).GetValue(childsT[i]) != null)
                                        childT.Key = childsT[i].GetType().GetProperty(childPropertyBind.Key).GetValue(childsT[i]).ToString();
                                }
                            }
                            if (childPropertyBind.Title != null)
                            {
                                if (childsT[i].GetType().GetProperty(childPropertyBind.Title) == null)
                                    childT.Title = childPropertyBind.Title;
                                else
                                {
                                    if (childsT[i].GetType().GetProperty(childPropertyBind.Title).GetValue(childsT[i]) != null)
                                        childT.Title = childsT[i].GetType().GetProperty(childPropertyBind.Title).GetValue(childsT[i]).ToString();
                                }

                            }
                            //if (childPropertyBind.Tooltip != null)
                            //{
                            //    if (childsT[i].GetType().GetProperty(childPropertyBind.Tooltip) == null)
                            //        childT.Tooltip = childPropertyBind.Tooltip;
                            //    else
                            //    {
                            //        if (childsT[i].GetType().GetProperty(childPropertyBind.Tooltip).GetValue(childsT[i]) != null)
                            //            childT.Tooltip = childsT[i].GetType().GetProperty(childPropertyBind.Tooltip).GetValue(childsT[i]).ToString();
                            //    }
                            //}
                            //if (childPropertyBind.Icon != null)
                            //{
                            //    if (childsT[i].GetType().GetProperty(childPropertyBind.Icon) == null)
                            //        childT.Icon = childPropertyBind.Icon;
                            //    else
                            //    {
                            //        if (childsT[i].GetType().GetProperty(childPropertyBind.Icon).GetValue(childsT[i]) != null)
                            //            childT.Icon = childsT[i].GetType().GetProperty(childPropertyBind.Icon).GetValue(childsT[i]).ToString();
                            //    }
                            //}
                            //if (childPropertyBind.SelectedIcon != null)
                            //{
                            //    if (childsT[i].GetType().GetProperty(childPropertyBind.SelectedIcon) == null)
                            //        childT.SelectedIcon = childPropertyBind.SelectedIcon;
                            //    else
                            //    {
                            //        if (childsT[i].GetType().GetProperty(childPropertyBind.SelectedIcon).GetValue(childsT[i]) != null)
                            //            childT.SelectedIcon = childsT[i].GetType().GetProperty(childPropertyBind.SelectedIcon).GetValue(childsT[i]).ToString();
                            //    }
                            //}
                            //if (childPropertyBind.Color != null)
                            //{
                            //    if (childsT[i].GetType().GetProperty(childPropertyBind.Color) == null)
                            //        childT.Color = childPropertyBind.Color;
                            //    else
                            //    {
                            //        if (childsT[i].GetType().GetProperty(childPropertyBind.Color).GetValue(childsT[i]) != null)
                            //            childT.Color = childsT[i].GetType().GetProperty(childPropertyBind.Color).GetValue(childsT[i]).ToString();
                            //    }
                            //}
                            //if (childPropertyBind.BackColor != null)
                            //{
                            //    if (childsT[i].GetType().GetProperty(childPropertyBind.BackColor) == null)
                            //        childT.BackColor = childPropertyBind.BackColor;
                            //    else
                            //    {
                            //        if (childsT[i].GetType().GetProperty(childPropertyBind.BackColor).GetValue(childsT[i]) != null)
                            //            childT.BackColor = childsT[i].GetType().GetProperty(childPropertyBind.BackColor).GetValue(childsT[i]).ToString();
                            //    }
                            //}
                            //if (childPropertyBind.Href != null)
                            //{
                            //    if (childsT[i].GetType().GetProperty(childPropertyBind.Href) == null)
                            //        childT.Href = childPropertyBind.Href;
                            //    else
                            //    {
                            //        if (childsT[i].GetType().GetProperty(childPropertyBind.Href).GetValue(childsT[i]) != null)
                            //            childT.Href = childsT[i].GetType().GetProperty(childPropertyBind.Href).GetValue(childsT[i]).ToString();
                            //    }
                            //}
                            if (childPropertyBind.Selectable != null)
                            {
                                if (childsT[i].GetType().GetProperty(childPropertyBind.Selectable) == null)
                                    childT.Selectable = bool.Parse(childPropertyBind.Selectable);
                                else
                                    childT.Selectable = (bool)childsT[i].GetType().GetProperty(childPropertyBind.Selectable).GetValue(childsT[i]);
                            }
                            if (childPropertyBind.Disabled != null)
                            {
                                if (childsT[i].GetType().GetProperty(childPropertyBind.Disabled) == null)
                                    childT.Disabled = bool.Parse(childPropertyBind.Disabled);
                                else
                                    childT.Disabled = (bool)childsT[i].GetType().GetProperty(childPropertyBind.Disabled).GetValue(childsT[i]);
                            }
                            //if (childPropertyBind.PreventUnselect != null)
                            //{
                            //    if (childsT[i].GetType().GetProperty(childPropertyBind.PreventUnselect) == null)
                            //        childT.PreventUnselect = bool.Parse(childPropertyBind.PreventUnselect);
                            //    else
                            //        childT.PreventUnselect = (bool)childsT[i].GetType().GetProperty(childPropertyBind.PreventUnselect).GetValue(childsT[i]);
                            //}
                            //if (childPropertyBind.AllowReselect != null)
                            //{
                            //    if (childsT[i].GetType().GetProperty(childPropertyBind.AllowReselect) == null)
                            //        childT.AllowReselect = bool.Parse(childPropertyBind.AllowReselect);
                            //    else
                            //        childT.AllowReselect = (bool)childsT[i].GetType().GetProperty(childPropertyBind.AllowReselect).GetValue(childsT[i]);
                            //}
                            //if (childPropertyBind.HideCheckbox != null)
                            //{
                            //    if (childsT[i].GetType().GetProperty(childPropertyBind.HideCheckbox) == null)
                            //        childT.HideCheckbox = bool.Parse(childPropertyBind.HideCheckbox);
                            //    else
                            //        childT.HideCheckbox = (bool)childsT[i].GetType().GetProperty(childPropertyBind.HideCheckbox).GetValue(childsT[i]);
                            //}
                            //if (childPropertyBind.State != null)
                            //{
                            //    childT.State.Selected = childPropertyBind.State.Selected;
                            //    childT.State.Checked = childPropertyBind.State.Checked;
                            //    childT.State.Disabled = childPropertyBind.State.Disabled;
                            //    childT.State.Expanded = childPropertyBind.State.Expanded;
                            //}
                            childT.Row = childsT[i];

                            // 判断传入的是否是Map类型，如果Map进行类型转换
                            if (childT.Row.GetType().ToString() != childPropertyBind.ChildPropertyClass)
                            {
                                MethodInfo method = childT.Row.GetType().GetMethod("ToMap", new Type[] { });
                                if (method != null)
                                {
                                    childT.Row = method.Invoke(childT.Row, new object[] { });
                                }
                            }

                            childs.Add(childT);
                        }
                    }

                }
            }
            catch (ArgumentException ex)
            {
                throw new ArgumentException(string.Format("实体类中未找到匹配属性。错误信息：{0}", ex.ToString()));
            }
            return childs;
        }

        /// <summary>
        /// 对泛型进行List实例化
        /// </summary>
        /// <param name="listType"></param>
        /// <returns></returns>
        private IList MakeListOfType(Type listType)
        {
            Type type = typeof(List<>);
            Type specificListType = type.MakeGenericType(listType);
            return (IList)Activator.CreateInstance(specificListType);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="childs"></param>
        /// <param name="config"></param>
        /// <returns></returns>
        private void FillTo(List<Child> childs, Config<T> config)
        {
            foreach (Child child in childs)
            {
                ////根据 IdSet 配置
                //foreach (IdSet idSet in config.IdSets)
                //{
                //    if (child.Id == idSet.Id)
                //    {
                //        //child.Selectable = idSet.Selectable;
                //        //child.Disabled = idSet.Disabled;
                //        if (!string.IsNullOrEmpty(idSet.Title))
                //            child.Title = idSet.Title;
                //        //if (!string.IsNullOrEmpty(idSet.Icon))
                //        //    child.Icon = idSet.Icon;
                //        //if (idSet.SelectedIcon != null)
                //        //    child.SelectedIcon = idSet.SelectedIcon;
                //        //if (!string.IsNullOrEmpty(idSet.Color))
                //        //    child.Color = idSet.Color;
                //        //if (!string.IsNullOrEmpty(idSet.BackColor))
                //        //    child.BackColor = idSet.BackColor;
                //        if (!string.IsNullOrEmpty(idSet.Href))
                //            child.Href = idSet.Href;
                //        //if (idSet.State != null)
                //        //    child.State = idSet.State;
                //        //if (idSet.Tags != null)
                //        //    child.Tags = idSet.Tags;
                //    }
                //    FillTo(child.Children, config);
                //}
                ////根据 LevelSet 配置
                //foreach (LevelSet levelSet in config.LevelSets)
                //{
                //    if (child.LevelIndex == levelSet.LevelIndex)
                //    {
                //        //child.Selectable = levelSet.Selectable;
                //        //child.Disabled = levelSet.Disabled;
                //        if (!string.IsNullOrEmpty(levelSet.Title))
                //            child.Title = levelSet.Title;
                //        //if (!string.IsNullOrEmpty(levelSet.Icon))
                //        //    child.Icon = levelSet.Icon;
                //        //if (levelSet.SelectedIcon != null)
                //        //    child.SelectedIcon = levelSet.SelectedIcon;
                //        //if (!string.IsNullOrEmpty(levelSet.Color))
                //        //    child.Color = levelSet.Color;
                //        //if (!string.IsNullOrEmpty(levelSet.BackColor))
                //        //    child.BackColor = levelSet.BackColor;
                //        if (!string.IsNullOrEmpty(levelSet.Href))
                //            child.Href = levelSet.Href;
                //        //if (levelSet.State != null)
                //        //    child.State = levelSet.State;
                //        //if (levelSet.Tags != null)
                //        //    child.Tags = levelSet.Tags;
                //    }
                //    FillTo(child.Children, config);
                //}

                //根据 KeySet 配置
                foreach (KeySet keySet in config.KeySets)
                {
                    if (child.Key == keySet.Key)
                    {
                        child.Selectable = keySet.Selectable;
                        child.Disabled = keySet.Disabled;
                        if (!string.IsNullOrEmpty(keySet.Title))
                            child.Title = keySet.Title;
                        //if (!string.IsNullOrEmpty(keySet.Icon))
                        //    child.Icon = keySet.Icon;
                        //if (keySet.SelectedIcon != null)
                        //    child.SelectedIcon = keySet.SelectedIcon;
                        //if (!string.IsNullOrEmpty(keySet.Color))
                        //    child.Color = keySet.Color;
                        //if (!string.IsNullOrEmpty(keySet.BackColor))
                        //    child.BackColor = keySet.BackColor;
                        //if (!string.IsNullOrEmpty(keySet.Href))
                        //    child.Href = keySet.Href;
                        //if (keySet.State != null)
                        //    child.State = keySet.State;
                        //if (keySet.Tags != null)
                        //    child.Tags = keySet.Tags;
                    }
                    FillTo(child.Children, config);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="childs">尚未排列成树形结构的Child集合</param>
        /// <returns></returns>
        protected List<Child> ToTree(List<Child> childs)
        {
            List<Child> rootChildren = childs.Where(
                        child => child.Pid == childs.Min(m => m.Pid)
                    ).ToList();
            LoopToAppendChildren(rootChildren, childs, 0);
            return rootChildren;
        }
        /// <summary>
        /// 节点递归方法
        /// </summary>
        /// <param name="rootChildren">已排列成树形结构的根节点</param>
        /// <param name="childs">尚未排列成树形结构的Child集合</param>
        /// <param name="levelIndex">已排列成树形结构的根节点LevelIndex</param>
        protected void LoopToAppendChildren(List<Child> rootChildren, List<Child> childs, int levelIndex)
        {
            foreach (var rootChild in rootChildren)
            {
                List<Child> subChildren = childs.Where(child => child.Pid == rootChild.Id).ToList();
                rootChild.Children = subChildren;
                rootChild.LevelIndex = levelIndex;
                LoopToAppendChildren(subChildren, childs, rootChild.LevelIndex + 1);
            }
        }

        #endregion
    }

    #region 定义 AntdTree 的 Child 属性

    /// <summary>
    /// 
    /// </summary>
    public class Child : ChildBase
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }
        ///// <summary>
        ///// 
        ///// </summary>
        //[JsonProperty(PropertyName = "tooltip")]
        //public string Tooltip { get; set; }
        ///// <summary>
        ///// 
        ///// </summary>
        //[JsonProperty(PropertyName = "icon")]
        //public string Icon { get; set; }
        /////// <summary>
        /////// 
        /////// </summary>
        ////[JsonProperty(PropertyName = "image")]
        ////public string Image { get; set; }
        ///// <summary>
        ///// 
        ///// </summary>
        //[JsonProperty(PropertyName = "selectedIcon")]
        //public string SelectedIcon { get; set; }
        ///// <summary>
        ///// 
        ///// </summary>
        //[JsonProperty(PropertyName = "color")]
        //public string Color { get; set; }
        ///// <summary>
        ///// 
        ///// </summary>
        //[JsonProperty(PropertyName = "backColor")]
        //public string BackColor { get; set; }
        ///// <summary>
        ///// 
        ///// </summary>
        //[JsonProperty(PropertyName = "lazyLoad")]
        //public bool LazyLoad { get; set; } = false;
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "selectable")]
        public bool Selectable { get; set; } = true;
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "disabled")]
        public bool Disabled { get; set; } = false;
        ///// <summary>
        ///// 
        ///// </summary>
        //[JsonProperty(PropertyName = "checkable")]
        //public bool Checkable { get; set; } = true;
        ///// <summary>
        ///// 
        ///// </summary>
        //[JsonProperty(PropertyName = "state")]
        //public State State { get; set; } = new State();
        ///// <summary>
        ///// 
        ///// </summary>
        //[JsonProperty(PropertyName = "tags")]
        //public List<string> Tags { get; set; } = new List<string>();
        ///// <summary>
        ///// 
        ///// </summary>
        //[JsonProperty(PropertyName = "tagsClass")]
        //public List<string> TagsClass { get; set; } = new List<string>();
        ///// <summary>
        ///// 
        ///// </summary>
        //[JsonProperty(PropertyName = "dataAttr")]
        //public List<object> DataAttr { get; set; } = new List<object>();
        ///// <summary>
        ///// 
        ///// </summary>
        //[JsonProperty(PropertyName = "class")]
        //public string Class { get; set; }



        ///// <summary>
        ///// 
        ///// </summary>
        //[JsonProperty(PropertyName = "borderColor")]
        //public string BorderColor { get; set; }
        ///// <summary>
        ///// 
        ///// </summary>
        //[JsonProperty(PropertyName = "changedChildColor")]
        //public string ChangedChildColor { get; set; }
        ///// <summary>
        ///// 
        ///// </summary>
        //[JsonProperty(PropertyName = "checkboxFirst")]
        //public bool CheckboxFirst { get; set; } = false;
        ///// <summary>
        ///// 
        ///// </summary>
        //[JsonProperty(PropertyName = "checkedIcon")]
        //public string CheckedIcon { get; set; }
        ///// <summary>
        ///// 
        ///// </summary>
        //[JsonProperty(PropertyName = "collapseIcon")]
        //public string CollapseIcon { get; set; }
        ///// <summary>
        ///// 
        ///// </summary>
        //[JsonProperty(PropertyName = "emptyIcon")]
        //public string EmptyIcon { get; set; }
        ///// <summary>
        ///// 
        ///// </summary>
        //[JsonProperty(PropertyName = "expandIcon")]
        //public string ExpandIcon { get; set; }
        ///// <summary>
        ///// 
        ///// </summary>
        //[JsonProperty(PropertyName = "loadingIcon")]
        //public string LoadingIcon { get; set; }
        ///// <summary>
        ///// 
        ///// </summary>
        //[JsonProperty(PropertyName = "hierarchicalCheck")]
        //public bool HierarchicalCheck { get; set; } = false;
        ///// <summary>
        ///// 
        ///// </summary>
        //[JsonProperty(PropertyName = "propagateCheckEvent")]
        //public bool PropagateCheckEvent { get; set; } = false;
        ///// <summary>
        ///// 
        ///// </summary>
        //[JsonProperty(PropertyName = "highlightChanges")]
        //public bool HighlightChanges { get; set; } = false;
        ///// <summary>
        ///// 
        ///// </summary>
        //[JsonProperty(PropertyName = "highlightSearchResults")]
        //public bool HighlightSearchResults { get; set; } = true;
        ///// <summary>
        ///// 
        ///// </summary>
        //[JsonProperty(PropertyName = "highlightSelected")]
        //public bool HighlightSelected { get; set; } = true;
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "levels")]
        public int Levels { get; set; } = 1;
        ///// <summary>
        ///// 
        ///// </summary>
        //[JsonProperty(PropertyName = "multiSelect")]
        //public bool MultiSelect { get; set; } = false;
        ///// <summary>
        ///// 
        ///// </summary>
        //[JsonProperty(PropertyName = "childIcon")]
        //public string ChildIcon { get; set; }
        /////// <summary>
        ///// 
        ///// </summary>
        //[JsonProperty(PropertyName = "onhoverColor")]
        //public string OnhoverColor { get; set; }
        ///// <summary>
        ///// 
        ///// </summary>
        //[JsonProperty(PropertyName = "partiallyCheckedIcon")]
        //public string PartiallyCheckedIcon { get; set; }
        ///// <summary>
        ///// 
        ///// </summary>
        //[JsonProperty(PropertyName = "preventUnselect")]
        //public bool PreventUnselect { get; set; } = false;
        ///// <summary>
        ///// 
        ///// </summary>
        //[JsonProperty(PropertyName = "allowReselect")]
        //public bool AllowReselect { get; set; } = true;
        ///// <summary>
        ///// 
        ///// </summary>
        //[JsonProperty(PropertyName = "searchResultBackColor")]
        //public string SearchResultBackColor { get; set; }
        ///// <summary>
        ///// 
        ///// </summary>
        //[JsonProperty(PropertyName = "searchResultColor")]
        //public string SearchResultColor { get; set; }
        ///// <summary>
        ///// 
        ///// </summary>
        //[JsonProperty(PropertyName = "selectedBackColor")]
        //public string SelectedBackColor { get; set; }
        ///// <summary>
        ///// 
        ///// </summary>
        //[JsonProperty(PropertyName = "selectedColor")]
        //public string SelectedColor { get; set; }
        ///// <summary>
        ///// 
        ///// </summary>
        //[JsonProperty(PropertyName = "showBorder")]
        //public bool ShowBorder { get; set; } = true;
        ///// <summary>
        ///// 
        ///// </summary>
        //[JsonProperty(PropertyName = "hideCheckbox")]
        //public bool HideCheckbox { get; set; } = false;
        ///// <summary>
        ///// 
        ///// </summary>
        //[JsonProperty(PropertyName = "showIcon")]
        //public bool ShowIcon { get; set; } = true;
        ///// <summary>
        ///// 
        ///// </summary>
        //[JsonProperty(PropertyName = "showImage")]
        //public bool ShowImage { get; set; } = false;
        ///// <summary>
        ///// 
        ///// </summary>
        //[JsonProperty(PropertyName = "showTags")]
        //public bool ShowTags { get; set; } = false;
        ///// <summary>
        ///// 
        ///// </summary>
        //[JsonProperty(PropertyName = "href")]
        //public string Href { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "key")]
        public new string Key { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "children")]
        public new List<Child> Children { get; set; } = new List<Child>();
    }

    #endregion

    #region 定义 AntdTree 的相关配置 Config
    /// <summary>
    /// 
    /// </summary>
    public class Config<T>
    {
        /// <summary>
        /// 
        /// </summary>
        public Config()
        {

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="title"></param>
        /// <param name="id"></param>
        /// <param name="pid"></param>
        /// <param name="selectable"></param>
        /// <param name="disabled"></param>
        public Config(string key, string title, string id, string pid, string selectable, string disabled)
        {
            //LevelSets = new List<LevelSet> {
            //        new LevelSet {
            //            LevelIndex = 0,
            //            State = new State { Expanded = false }
            //        }
            //    };
            PropertyBind = new PropertyBind
            {
                Key = key,
                Title = title,
                Id = id,
                Pid = pid,
                Selectable = selectable,
                Disabled = disabled
            };
        }
        ///// <summary>
        ///// 
        ///// </summary>
        //[JsonProperty(PropertyName = "checkedRows")]
        //public virtual List<T> CheckedRows { get; set; } = new List<T>();
        ///// <summary>
        ///// 
        ///// </summary>
        //[JsonProperty(PropertyName = "expandedRows")]
        //public virtual List<T> ExpandedRows { get; set; } = new List<T>();
        ///// <summary>
        ///// 
        ///// </summary>
        //[JsonProperty(PropertyName = "selectedRows")]
        //public virtual List<T> SelectedRows { get; set; } = new List<T>();
        ///// <summary>
        ///// 
        ///// </summary>
        //[JsonProperty(PropertyName = "disabledRows")]
        //public virtual List<T> DisabledRows { get; set; } = new List<T>();
        ///// <summary>
        ///// 
        ///// </summary>
        //[JsonProperty(PropertyName = "idSets")]
        //public List<IdSet> IdSets { get; set; } = new List<IdSet>();
        ///// <summary>
        ///// 
        ///// </summary>
        //[JsonProperty(PropertyName = "levelSets")]
        //public List<LevelSet> LevelSets { get; set; } = new List<LevelSet>();
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "keySets")]
        public List<KeySet> KeySets { get; set; } = new List<KeySet>();
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "propertyBind")]
        public PropertyBind PropertyBind { get; set; } = new PropertyBind();
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "childPropertyBinds")]
        public List<ChildPropertyBind> ChildPropertyBinds = new List<ChildPropertyBind>();
    }
    #endregion

    #region AntdTree 内部类 InnerClass

    #region IdSet
    ///// <summary>
    ///// 树节点设置，用以替换Json中的对应内容。
    ///// </summary>
    //public class IdSet : IdSetBase
    //{
    //    /// <summary>
    //    /// 
    //    /// </summary>
    //    [JsonProperty(PropertyName = "title")]
    //    public string Title { get; set; }
    //    /// <summary>
    //    /// 
    //    /// </summary>
    //    [JsonProperty(PropertyName = "icon")]
    //    public string Icon { get; set; }
    //    /// <summary>
    //    /// 
    //    /// </summary>
    //    [JsonProperty(PropertyName = "selectedIcon")]
    //    public string SelectedIcon { get; set; }
    //    /// <summary>
    //    /// 
    //    /// </summary>
    //    [JsonProperty(PropertyName = "color")]
    //    public string Color { get; set; }
    //    /// <summary>
    //    /// 
    //    /// </summary>
    //    [JsonProperty(PropertyName = "backColor")]
    //    public string BackColor { get; set; }
    //    /// <summary>
    //    /// 
    //    /// </summary>
    //    [JsonProperty(PropertyName = "href")]
    //    public string Href { get; set; }
    //    /// <summary>
    //    /// 
    //    /// </summary>
    //    [JsonProperty(PropertyName = "selectable")]
    //    public bool Selectable { get; set; } = true;
    //    /// <summary>
    //    /// 
    //    /// </summary>
    //    [JsonProperty(PropertyName = "disabled")]
    //    public bool Disabled { get; set; } = false;
    //    /// <summary>
    //    /// 
    //    /// </summary>
    //    [JsonProperty(PropertyName = "state")]
    //    public State State { get; set; } = new State();
    //    /// <summary>
    //    /// 
    //    /// </summary>
    //    [JsonProperty(PropertyName = "tags")]
    //    public List<string> Tags { get; set; } = new List<string>();
    //}
    #endregion

    #region LevelSet
    ///// <summary>
    ///// 
    ///// </summary>
    //public class LevelSet : LevelSetBase
    //{
    //    /// <summary>
    //    /// 
    //    /// </summary>
    //    [JsonProperty(PropertyName = "title")]
    //    public string Title { get; set; }
    //    /// <summary>
    //    /// 
    //    /// </summary>
    //    [JsonProperty(PropertyName = "icon")]
    //    public string Icon { get; set; }
    //    /// <summary>
    //    /// 
    //    /// </summary>
    //    [JsonProperty(PropertyName = "selectedIcon")]
    //    public string SelectedIcon { get; set; }
    //    /// <summary>
    //    /// 
    //    /// </summary>
    //    [JsonProperty(PropertyName = "color")]
    //    public string Color { get; set; }
    //    /// <summary>
    //    /// 
    //    /// </summary>
    //    [JsonProperty(PropertyName = "backColor")]
    //    public string BackColor { get; set; }
    //    /// <summary>
    //    /// 
    //    /// </summary>
    //    [JsonProperty(PropertyName = "href")]
    //    public string Href { get; set; }
    //    /// <summary>
    //    /// 
    //    /// </summary>
    //    [JsonProperty(PropertyName = "selectable")]
    //    public bool Selectable { get; set; } = true;
    //    /// <summary>
    //    /// 
    //    /// </summary>
    //    [JsonProperty(PropertyName = "disabled")]
    //    public bool Disabled { get; set; } = true;
    //    /// <summary>
    //    /// 
    //    /// </summary>
    //    [JsonProperty(PropertyName = "state")]
    //    public State State { get; set; } = new State();
    //    /// <summary>
    //    /// 
    //    /// </summary>
    //    [JsonProperty(PropertyName = "tags")]
    //    public List<string> Tags { get; set; } = new List<string>();
    //}
    #endregion

    #region KeySet
    /// <summary>
    /// 
    /// </summary>
    public class KeySet : KeySetBase
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }
        ///// <summary>
        ///// 
        ///// </summary>
        //[JsonProperty(PropertyName = "icon")]
        //public string Icon { get; set; }
        ///// <summary>
        ///// 
        ///// </summary>
        //[JsonProperty(PropertyName = "selectedIcon")]
        //public string SelectedIcon { get; set; }
        ///// <summary>
        ///// 
        ///// </summary>
        //[JsonProperty(PropertyName = "color")]
        //public string Color { get; set; }
        ///// <summary>
        ///// 
        ///// </summary>
        //[JsonProperty(PropertyName = "backColor")]
        //public string BackColor { get; set; }
        ///// <summary>
        ///// 
        ///// </summary>
        //[JsonProperty(PropertyName = "href")]
        //public string Href { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "selectable")]
        public bool Selectable { get; set; } = true;
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "disabled")]
        public bool Disabled { get; set; } = true;
        ///// <summary>
        ///// 
        ///// </summary>
        //[JsonProperty(PropertyName = "state")]
        //public State State { get; set; } = new State();
        ///// <summary>
        ///// 
        ///// </summary>
        //[JsonProperty(PropertyName = "tags")]
        //public List<string> Tags { get; set; } = new List<string>();
    }
    #endregion

    #region PropertyBind
    /// <summary>
    /// 用于指定树控件的属性分别对应的是实体类中的哪些字段
    ///     即：绑定树控件属性与实体类属性
    /// </summary>
    public class PropertyBind : PropertyBindBase
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }
        ///// <summary>
        ///// 
        ///// </summary>
        //[JsonProperty(PropertyName = "tooltip")]
        //public string Tooltip { get; set; }
        ///// <summary>
        ///// 
        ///// </summary>
        //[JsonProperty(PropertyName = "icon")]
        //public string Icon { get; set; }
        ///// <summary>
        ///// 
        ///// </summary>
        //[JsonProperty(PropertyName = "image")]
        //public string Image { get; set; }
        ///// <summary>
        ///// 
        ///// </summary>
        //[JsonProperty(PropertyName = "selectedIcon")]
        //public string SelectedIcon { get; set; }
        ///// <summary>
        ///// 
        ///// </summary>
        //[JsonProperty(PropertyName = "color")]
        //public string Color { get; set; }
        ///// <summary>
        ///// 
        ///// </summary>
        //[JsonProperty(PropertyName = "backColor")]
        //public string BackColor { get; set; }
        ///// <summary>
        ///// 
        ///// </summary>
        //[JsonProperty(PropertyName = "lazyLoad")]
        //public string LazyLoad { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "selectable")]
        public string Selectable { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "disabled")]
        public string Disabled { get; set; }
        ///// <summary>
        ///// 
        ///// </summary>
        //[JsonProperty(PropertyName = "checkable")]
        //public string Checkable { get; set; }
        ///// <summary>
        ///// 
        ///// </summary>
        //[JsonProperty(PropertyName = "state")]
        //public State State { get; set; } = new State();
        ///// <summary>
        ///// 
        ///// </summary>
        //[JsonProperty(PropertyName = "class")]
        //public string Class { get; set; }



        ///// <summary>
        ///// 
        ///// </summary>
        //[JsonProperty(PropertyName = "borderColor")]
        //public string BorderColor { get; set; }
        ///// <summary>
        ///// 
        ///// </summary>
        //[JsonProperty(PropertyName = "changedChildColor")]
        //public string ChangedChildColor { get; set; }
        ///// <summary>
        ///// 
        ///// </summary>
        //[JsonProperty(PropertyName = "checkboxFirst")]
        //public string CheckboxFirst { get; set; }
        ///// <summary>
        ///// 
        ///// </summary>
        //[JsonProperty(PropertyName = "checkedIcon")]
        //public string CheckedIcon { get; set; }
        ///// <summary>
        ///// 
        ///// </summary>
        //[JsonProperty(PropertyName = "collapseIcon")]
        //public string CollapseIcon { get; set; }
        ///// <summary>
        ///// 
        ///// </summary>
        //[JsonProperty(PropertyName = "emptyIcon")]
        //public string EmptyIcon { get; set; }
        ///// <summary>
        ///// 
        ///// </summary>
        //[JsonProperty(PropertyName = "expandIcon")]
        //public string ExpandIcon { get; set; }
        ///// <summary>
        ///// 
        ///// </summary>
        //[JsonProperty(PropertyName = "loadingIcon")]
        //public string LoadingIcon { get; set; }
        ///// <summary>
        ///// 
        ///// </summary>
        //[JsonProperty(PropertyName = "hierarchicalCheck")]
        //public string HierarchicalCheck { get; set; }
        ///// <summary>
        ///// 
        ///// </summary>
        //[JsonProperty(PropertyName = "propagateCheckEvent")]
        //public string PropagateCheckEvent { get; set; }
        ///// <summary>
        ///// 
        ///// </summary>
        //[JsonProperty(PropertyName = "highlightChanges")]
        //public string HighlightChanges { get; set; }
        ///// <summary>
        ///// 
        ///// </summary>
        //[JsonProperty(PropertyName = "highlightSearchResults")]
        //public string HighlightSearchResults { get; set; }
        ///// <summary>
        ///// 
        ///// </summary>
        //[JsonProperty(PropertyName = "highlightSelected")]
        //public string HighlightSelected { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "levels")]
        public string Levels { get; set; }
        ///// <summary>
        ///// 
        ///// </summary>
        ////[JsonProperty(PropertyName = "multiSelect")]
        ////public string MultiSelect { get; set; }
        ///// <summary>
        ///// 
        ///// </summary>
        //[JsonProperty(PropertyName = "childIcon")]
        //public string ChildIcon { get; set; }
        ///// <summary>
        ///// 
        ///// </summary>
        //[JsonProperty(PropertyName = "onhoverColor")]
        //public string OnhoverColor { get; set; }
        ///// <summary>
        ///// 
        ///// </summary>
        //[JsonProperty(PropertyName = "partiallyCheckedIcon")]
        //public string PartiallyCheckedIcon { get; set; }
        ///// <summary>
        ///// 
        ///// </summary>
        //[JsonProperty(PropertyName = "preventUnselect")]
        //public string PreventUnselect { get; set; }
        ///// <summary>
        ///// 
        ///// </summary>
        //[JsonProperty(PropertyName = "allowReselect")]
        //public string AllowReselect { get; set; }
        ///// <summary>
        ///// 
        ///// </summary>
        //[JsonProperty(PropertyName = "searchResultBackColor")]
        //public string SearchResultBackColor { get; set; }
        ///// <summary>
        ///// 
        ///// </summary>
        //[JsonProperty(PropertyName = "searchResultColor")]
        //public string SearchResultColor { get; set; }
        ///// <summary>
        ///// 
        ///// </summary>
        //[JsonProperty(PropertyName = "selectedBackColor")]
        //public string SelectedBackColor { get; set; }
        ///// <summary>
        ///// 
        ///// </summary>
        //[JsonProperty(PropertyName = "selectedColor")]
        //public string SelectedColor { get; set; }
        ///// <summary>
        ///// 
        ///// </summary>
        //[JsonProperty(PropertyName = "showBorder")]
        //public string ShowBorder { get; set; }
        ///// <summary>
        ///// 
        ///// </summary>
        //[JsonProperty(PropertyName = "hideCheckbox")]
        //public string HideCheckbox { get; set; }
        ///// <summary>
        ///// 
        ///// </summary>
        //[JsonProperty(PropertyName = "showIcon")]
        //public string ShowIcon { get; set; }
        ///// <summary>
        ///// 
        ///// </summary>
        //[JsonProperty(PropertyName = "showImage")]
        //public string ShowImage { get; set; }
        ///// <summary>
        ///// 
        ///// </summary>
        //[JsonProperty(PropertyName = "showTags")]
        //public string ShowTags { get; set; }
        ///// <summary>
        ///// 
        ///// </summary>
        //[JsonProperty(PropertyName = "href")]
        //public string Href { get; set; }
    }
    #endregion

    #region ChildrenPropertyBind

    /// <summary>
    /// 
    /// </summary>
    public class ChildPropertyBind : PropertyBind
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "childPropertyName")]
        public string ChildPropertyName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "childPropertyClass")]
        public string ChildPropertyClass { get; set; }
    }
    #endregion

    #region State
    /// <summary>
    /// antdTree节点的State属性
    /// </summary>
    public class State
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "checked")]
        public bool Checked { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "disabled")]
        public bool Disabled { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "expanded")]
        public bool Expanded { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "selected")]
        public bool Selected { get; set; }
    }
    #endregion

    #endregion
}