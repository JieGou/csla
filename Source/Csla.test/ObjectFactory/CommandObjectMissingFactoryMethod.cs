﻿//-----------------------------------------------------------------------
// <copyright file="CommandObjectMissingFactoryMethod.cs" company="Marimer LLC">
//     Copyright (c) Marimer LLC. All rights reserved.
//     Website: https://cslanet.com
// </copyright>
// <summary>no summary</summary>
//-----------------------------------------------------------------------

namespace Csla.Test.ObjectFactory
{
  [Csla.Server.ObjectFactory("Csla.Test.ObjectFactory.CommandObjectFactory, Csla.Test", null, null, null, null, "ExecuteMissingMethod")]
  [Serializable]
  public class CommandObjectMissingFactoryMethod : CommandBase<CommandObjectMissingFactoryMethod>
  {
    #region Authorization Methods

    public static bool CanExecuteCommand()
    {
      return true;
    }

    #endregion

    #region Factory Methods

    public static bool Execute(IDataPortal<CommandObjectMissingFactoryMethod> dataPortal)
    {
      if (!CanExecuteCommand())
        throw new Csla.Security.SecurityException("Not authorized to execute command");

      CommandObjectMissingFactoryMethod cmd = dataPortal.Create();
      cmd.BeforeServer();
      cmd = dataPortal.Execute(cmd);
      cmd.AfterServer();
      return cmd.Result;
    }

    #endregion

    #region Client-side Code

    public static readonly PropertyInfo<bool> ResultProperty = RegisterProperty<CommandObjectMissingFactoryMethod, bool>(p => p.Result);
    public bool Result
    {
      get { return ReadProperty<bool>(ResultProperty); }
      set { LoadProperty<bool>(ResultProperty, value); }
    }

    private void BeforeServer()
    {
    }

    private void AfterServer()
    {
    }

    #endregion

    [RunLocal]
    [Create]
    private void Create()
    { }

  }
}