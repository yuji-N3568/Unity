// Copyright (c) 2021 homuler
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace Mediapipe.Unity.Sample.UI
{
  public class ImageSourceConfig : ModalContents
  {
    private const string _SourcePath = "Scroll View/Viewport/Contents/Source/Dropdown";
    private const string _ResolutionPath = "Scroll View/Viewport/Contents/Resolution/Dropdown";

    private Solution _solution;
    private Dropdown _sourceInput;
    private Dropdown _resolutionInput;

    private bool _isChanged;

    private void Start()
    {
      _solution = GameObject.Find("Solution").GetComponent<Solution>();
      InitializeContents();
    }

    public override void Exit()
    {
      GetModal().CloseAndResume(_isChanged);
    }

    private void InitializeContents()
    {
      InitializeSource();
      InitializeResolution();
    }

    private void InitializeSource()
    {
      _sourceInput = gameObject.transform.Find(_SourcePath).gameObject.GetComponent<Dropdown>();
      _sourceInput.ClearOptions();
      _sourceInput.onValueChanged.RemoveAllListeners();

      var imageSource = ImageSourceProvider.ImageSource;
      var sourceNames = imageSource.sourceCandidateNames;

      if (sourceNames == null)
      {
        _sourceInput.enabled = false;
        return;
      }

      var options = new List<string>(sourceNames);
      _sourceInput.AddOptions(options);

      var currentSourceName = imageSource.sourceName;
      var defaultValue = options.FindIndex(option => option == currentSourceName);

      if (defaultValue >= 0)
      {
        _sourceInput.value = defaultValue;
      }

      _sourceInput.onValueChanged.AddListener(delegate
      {
        imageSource.SelectSource(_sourceInput.value);
        _isChanged = true;
        InitializeResolution();
      });
    }

    private void InitializeResolution()
    {
      _resolutionInput = gameObject.transform.Find(_ResolutionPath).gameObject.GetComponent<Dropdown>();
      _resolutionInput.ClearOptions();
      _resolutionInput.onValueChanged.RemoveAllListeners();

      var imageSource = ImageSourceProvider.ImageSource;
      var resolutions = imageSource.availableResolutions;

      if (resolutions == null)
      {
        _resolutionInput.enabled = false;
        return;
      }

      var options = resolutions.Select(resolution => resolution.ToString()).ToList();
      _resolutionInput.AddOptions(options);

      var currentResolutionStr = imageSource.resolution.ToString();
      var defaultValue = options.FindIndex(option => option == currentResolutionStr);

      if (defaultValue >= 0)
      {
        _resolutionInput.value = defaultValue;
      }

      _resolutionInput.onValueChanged.AddListener(delegate
      {
        imageSource.SelectResolution(_resolutionInput.value);
        _isChanged = true;
      });
    }

  }
}
