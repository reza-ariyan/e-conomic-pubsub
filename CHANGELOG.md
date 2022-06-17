# Change Log

All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](http://keepachangelog.com/)
and this project adheres to [Semantic Versioning](http://semver.org/).

## [Unreleased] - 2022-06-17

### Added
- Ability to automatically subscribe to a message by using dependency injection
- Unsubscription on disposing a subscriber (eg. due to connection loss)

### Fixed
- Notify action access modifier for subscriber has been changed to be able to write tests and be called separately

## [1.0.0] - 2022-06-17

Updates for version 1.0.0 (first version):

### Added

- Local Event Bus for handling publishing and subscriptions locally
- Ability to inject pub-sub instead of creating new instances manually

### Changed

- Removed some empty classes from projects
- Some documentations added to PubSub.Core project