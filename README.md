# Vostok.Logging.NUnit

[![Build & Test & Publish](https://github.com/vostok/logging.nunit/actions/workflows/ci.yml/badge.svg)](https://github.com/vostok/logging.nunit/actions/workflows/ci.yml)
[![NuGet](https://img.shields.io/nuget/v/Vostok.Logging.NUnit.svg)](https://www.nuget.org/packages/Vostok.Logging.NUnit/)

An implementation of ILog that writes log events to NUnit.

**Build guide**: https://github.com/vostok/devtools/blob/master/library-dev-conventions/how-to-build-a-library.md

**User documentation**: https://vostok.gitbook.io/logging/


## ILog adapter of NUnit log.

Logs can be written to:
1) The context of the test, which is currently running. It is suitable for most of the tests. 
(`NUnitLogSettings.WithAsyncLocalContext()`)

2) The context of the test, in which the log was created. It is suitable for local services and other places where AsyncLocal context can be lost or absent. 
(`NUnitLogSettings.WithCurrentTestContext()`)
