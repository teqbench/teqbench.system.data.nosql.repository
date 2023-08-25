# Overview
Base implementation for a NoSql document repository. Override the appropriate methods to create DB if does not exist, create collection if does not exist (might not need to implement as in case of MongoDB...collection will be created upon first reference if does not exist), as well as methods to dispose of managed/unmanaged objects.
# Build
# Deployment