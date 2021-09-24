﻿using NUnit.Framework;
using System;
using System.IO;
using System.Linq;

namespace CopyBinaryFile.Tests
{
    [TestFixture]
    public class TestOne
    {
        private string sourceFile;
        private string expectedOutput;

        private readonly byte[] sourceContent = { 137, 80, 78, 71, 13, 10, 26, 10, 0, 0, 0, 13, 73, 72, 68, 82, 0, 0, 0, 75, 0, 0, 0, 85, 8, 2, 0, 0, 0, 142, 240, 142, 86, 0, 0, 0, 1, 115, 82, 71, 66, 0, 174, 206, 28, 233, 0, 0, 0, 4, 103, 65, 77, 65, 0, 0, 177, 143, 11, 252, 97, 5, 0, 0, 0, 9, 112, 72, 89, 115, 0, 0, 14, 195, 0, 0, 14, 195, 1, 199, 111, 168, 100, 0, 0, 8, 46, 73, 68, 65, 84, 120, 94, 237, 155, 217, 79, 19, 93, 24, 198, 65, 16, 4, 197, 130, 11, 246, 70, 148, 68, 75, 226, 194, 226, 134, 91, 226, 74, 140, 127, 128, 81, 19, 99, 226, 18, 183, 27, 151, 196, 68, 69, 208, 72, 0, 47, 52, 94, 34, 137, 75, 226, 26, 252, 11, 212, 104, 53, 18, 227, 6, 26, 35, 23, 164, 26, 209, 122, 83, 5, 215, 162, 72, 241, 195, 239, 23, 206, 120, 24, 166, 211, 233, 116, 90, 108, 199, 240, 92, 12, 115, 150, 153, 121, 158, 243, 156, 247, 61, 167, 165, 147, 252, 227, 199, 143, 164, 127, 26, 195, 148, 191, 255, 46, 134, 20, 218, 31, 214, 21, 38, 39, 39, 43, 103, 73, 73, 191, 127, 255, 86, 206, 66, 128, 206, 97, 251, 12, 18, 98, 227, 161, 90, 173, 46, 144, 167, 233, 163, 43, 216, 248, 62, 214, 198, 40, 150, 185, 84, 99, 84, 111, 111, 239, 127, 125, 16, 149, 20, 101, 43, 61, 5, 134, 245, 33, 37, 37, 133, 163, 104, 146, 160, 213, 154, 36, 13, 98, 160, 16, 30, 130, 46, 39, 224, 87, 31, 190, 126, 253, 218, 218, 218, 218, 210, 210, 226, 241, 120, 222, 190, 125, 235, 243, 249, 62, 127, 254, 204, 179, 122, 122, 122, 134, 15, 31, 158, 153, 153, 153, 147, 147, 227, 116, 58, 39, 77, 154, 228, 114, 185, 102, 204, 152, 81, 80, 80, 144, 157, 157, 157, 218, 7, 110, 37, 238, 44, 238, 41, 206, 45, 35, 102, 30, 226, 85, 32, 16, 240, 122, 189, 110, 183, 251, 206, 157, 59, 79, 159, 62, 253, 242, 229, 139, 244, 80, 109, 160, 0, 236, 241, 141, 35, 6, 162, 106, 244, 232, 209, 37, 37, 37, 203, 251, 144, 151, 151, 151, 158, 158, 78, 189, 210, 53, 58, 196, 64, 33, 142, 249, 253, 254, 135, 15, 31, 94, 185, 114, 165, 177, 177, 17, 247, 168, 65, 152, 210, 108, 26, 66, 170, 195, 225, 88, 188, 120, 241, 250, 245, 235, 23, 46, 92, 152, 149, 149, 133, 225, 98, 104, 44, 251, 25, 149, 66, 156, 65, 219, 173, 91, 183, 234, 235, 235, 159, 61, 123, 246, 243, 231, 79, 147, 194, 4, 221, 80, 164, 145, 58, 98, 196, 136, 162, 162, 162, 29, 59, 118, 148, 149, 149, 161, 51, 56, 74, 205, 195, 186, 66, 244, 52, 53, 53, 157, 56, 113, 226, 254, 253, 251, 93, 93, 93, 168, 53, 51, 204, 193, 125, 100, 141, 166, 9, 85, 25, 25, 25, 56, 185, 127, 255, 254, 217, 179, 103, 19, 186, 97, 111, 174, 11, 43, 10, 17, 243, 225, 195, 7, 124, 59, 123, 246, 44, 249, 3, 223, 204, 104, 179, 6, 252, 36, 3, 109, 218, 180, 105, 215, 174, 93, 185, 185, 185, 193, 102, 242, 92, 158, 174, 20, 244, 16, 177, 66, 146, 225, 243, 231, 207, 43, 43, 43, 9, 60, 108, 84, 106, 7, 1, 234, 81, 99, 210, 150, 150, 150, 86, 85, 85, 49, 117, 137, 76, 81, 105, 18, 145, 41, 68, 210, 245, 235, 215, 43, 42, 42, 222, 188, 121, 99, 33, 151, 68, 3, 204, 100, 105, 65, 228, 234, 213, 171, 17, 172, 212, 154, 64, 4, 17, 76, 176, 93, 186, 116, 105, 247, 238, 221, 175, 95, 191, 14, 37, 207, 120, 194, 68, 3, 158, 216, 214, 214, 182, 103, 207, 158, 139, 23, 47, 74, 87, 204, 132, 134, 89, 15, 233, 118, 254, 252, 249, 234, 234, 106, 86, 57, 81, 51, 120, 177, 103, 12, 150, 147, 242, 242, 242, 45, 91, 182, 224, 164, 153, 1, 13, 239, 33, 50, 152, 156, 172, 117, 53, 53, 53, 200, 147, 55, 141, 139, 60, 192, 122, 91, 91, 91, 123, 249, 242, 229, 238, 238, 110, 165, 202, 16, 225, 21, 178, 124, 223, 184, 113, 3, 247, 72, 155, 20, 227, 37, 12, 200, 193, 133, 9, 124, 200, 8, 164, 61, 81, 99, 128, 240, 179, 148, 165, 124, 227, 198, 141, 196, 94, 28, 181, 5, 3, 181, 249, 249, 249, 23, 46, 92, 40, 46, 46, 54, 222, 15, 132, 241, 176, 189, 189, 253, 192, 129, 3, 100, 206, 132, 146, 7, 224, 195, 134, 254, 224, 193, 131, 31, 63, 126, 52, 230, 166, 175, 80, 92, 67, 248, 213, 213, 213, 61, 121, 242, 228, 47, 47, 12, 38, 1, 43, 184, 157, 62, 125, 218, 56, 32, 245, 21, 50, 7, 216, 184, 48, 63, 207, 157, 59, 55, 168, 203, 122, 148, 128, 27, 251, 42, 120, 194, 86, 169, 250, 3, 105, 108, 191, 66, 170, 212, 201, 183, 179, 179, 243, 212, 169, 83, 204, 1, 165, 156, 144, 128, 48, 12, 225, 9, 91, 165, 234, 15, 164, 150, 1, 30, 34, 82, 72, 103, 2, 240, 25, 239, 238, 221, 187, 137, 57, 63, 37, 96, 11, 67, 120, 26, 80, 237, 87, 40, 68, 139, 227, 247, 239, 223, 217, 88, 27, 164, 89, 181, 219, 113, 7, 60, 97, 11, 103, 81, 20, 38, 73, 232, 196, 33, 131, 193, 174, 186, 185, 185, 57, 120, 114, 75, 104, 238, 18, 95, 192, 19, 182, 143, 30, 61, 18, 54, 170, 173, 2, 58, 10, 3, 129, 192, 181, 107, 215, 216, 133, 42, 229, 4, 131, 238, 244, 193, 198, 134, 134, 6, 152, 43, 101, 149, 7, 90, 133, 52, 188, 127, 255, 158, 143, 237, 108, 101, 148, 170, 4, 131, 238, 244, 129, 237, 237, 219, 183, 249, 212, 170, 148, 85, 208, 42, 20, 129, 251, 237, 219, 55, 165, 108, 31, 176, 95, 37, 59, 6, 27, 163, 85, 72, 15, 183, 219, 109, 102, 191, 151, 104, 128, 51, 204, 225, 31, 38, 14, 153, 208, 50, 100, 237, 5, 56, 63, 126, 252, 24, 254, 98, 26, 235, 199, 33, 73, 233, 229, 203, 151, 9, 190, 202, 27, 160, 163, 163, 227, 213, 171, 87, 114, 9, 16, 34, 181, 10, 91, 90, 90, 236, 104, 160, 0, 204, 225, 47, 21, 138, 137, 170, 85, 232, 241, 120, 100, 15, 219, 65, 242, 87, 231, 91, 173, 66, 175, 215, 107, 95, 15, 5, 127, 142, 234, 79, 140, 90, 133, 62, 159, 79, 119, 73, 181, 5, 176, 14, 254, 70, 30, 146, 106, 253, 126, 191, 186, 217, 94, 128, 57, 43, 185, 88, 234, 164, 10, 173, 66, 54, 62, 246, 85, 8, 224, 47, 162, 76, 127, 61, 68, 155, 125, 131, 80, 0, 254, 26, 135, 6, 40, 68, 119, 74, 74, 138, 125, 227, 16, 4, 243, 31, 160, 144, 230, 244, 244, 116, 91, 207, 82, 248, 167, 166, 166, 42, 133, 62, 12, 80, 152, 150, 150, 150, 149, 149, 101, 95, 15, 97, 14, 127, 35, 133, 244, 152, 48, 97, 130, 173, 21, 58, 157, 78, 177, 24, 234, 231, 82, 218, 242, 242, 242, 212, 203, 165, 189, 212, 170, 249, 75, 230, 90, 133, 46, 151, 75, 221, 195, 94, 49, 9, 243, 169, 83, 167, 10, 254, 18, 90, 133, 51, 103, 206, 36, 223, 112, 110, 199, 124, 67, 4, 22, 22, 22, 134, 81, 56, 101, 202, 148, 113, 227, 198, 41, 101, 91, 129, 73, 7, 115, 248, 27, 41, 4, 153, 153, 153, 243, 230, 205, 19, 54, 218, 11, 112, 158, 59, 119, 110, 70, 70, 134, 82, 254, 3, 173, 66, 140, 94, 190, 124, 121, 164, 255, 43, 79, 4, 192, 124, 197, 138, 21, 28, 69, 124, 233, 103, 26, 64, 143, 101, 203, 150, 57, 28, 14, 165, 108, 31, 100, 103, 103, 195, 28, 254, 50, 71, 138, 147, 126, 133, 50, 181, 228, 230, 230, 138, 193, 16, 69, 91, 128, 73, 7, 103, 152, 43, 229, 62, 8, 69, 253, 10, 165, 173, 236, 108, 214, 174, 93, 75, 64, 138, 162, 45, 64, 248, 173, 89, 179, 70, 19, 92, 90, 133, 18, 132, 108, 105, 105, 233, 156, 57, 115, 52, 73, 41, 97, 1, 79, 216, 206, 159, 63, 95, 147, 32, 181, 179, 84, 122, 136, 244, 145, 35, 71, 110, 219, 182, 141, 163, 168, 73, 88, 8, 206, 240, 220, 190, 125, 123, 40, 182, 58, 113, 200, 101, 12, 198, 210, 165, 75, 151, 44, 89, 146, 152, 203, 134, 218, 12, 12, 36, 193, 192, 86, 151, 42, 61, 181, 243, 80, 94, 60, 106, 212, 168, 125, 251, 246, 169, 87, 127, 217, 20, 119, 72, 51, 192, 248, 241, 227, 247, 238, 221, 27, 108, 32, 125, 4, 180, 10, 169, 18, 39, 140, 77, 113, 113, 241, 214, 173, 91, 229, 79, 172, 100, 83, 226, 0, 110, 48, 44, 42, 42, 10, 78, 25, 248, 33, 44, 209, 54, 0, 233, 21, 215, 51, 191, 131, 35, 56, 65, 0, 43, 184, 237, 220, 185, 147, 79, 189, 74, 149, 10, 253, 86, 137, 63, 106, 168, 189, 26, 59, 118, 236, 241, 227, 199, 243, 243, 243, 165, 236, 4, 1, 124, 96, 85, 91, 91, 155, 147, 147, 163, 203, 77, 86, 234, 40, 84, 131, 126, 211, 166, 77, 171, 169, 169, 209, 44, 166, 113, 7, 124, 170, 171, 171, 225, 22, 118, 232, 195, 40, 4, 108, 110, 86, 174, 92, 89, 89, 89, 57, 102, 204, 24, 165, 234, 239, 34, 88, 3, 76, 42, 42, 42, 202, 202, 202, 228, 198, 203, 32, 71, 132, 87, 8, 8, 72, 118, 57, 229, 229, 229, 113, 17, 169, 97, 207, 254, 243, 208, 161, 67, 235, 214, 173, 99, 31, 35, 197, 27, 56, 25, 193, 47, 104, 187, 186, 186, 26, 26, 26, 142, 30, 61, 218, 222, 222, 174, 59, 102, 60, 198, 96, 44, 163, 7, 247, 103, 109, 56, 114, 228, 136, 144, 167, 212, 134, 131, 89, 133, 130, 122, 32, 16, 184, 121, 243, 38, 102, 182, 181, 181, 253, 229, 239, 142, 153, 144, 147, 39, 79, 174, 170, 170, 90, 181, 106, 149, 92, 192, 204, 32, 178, 95, 65, 131, 158, 158, 158, 23, 47, 94, 28, 62, 124, 120, 176, 127, 231, 173, 6, 146, 22, 44, 88, 112, 236, 216, 177, 194, 194, 66, 177, 189, 102, 196, 213, 51, 83, 83, 84, 35, 98, 133, 160, 183, 183, 183, 163, 163, 163, 174, 174, 238, 204, 153, 51, 226, 197, 24, 165, 97, 16, 192, 162, 199, 122, 176, 121, 243, 102, 214, 61, 242, 167, 65, 188, 133, 130, 21, 133, 2, 221, 221, 221, 77, 77, 77, 39, 79, 158, 188, 119, 239, 30, 102, 34, 91, 105, 136, 17, 216, 166, 16, 108, 139, 22, 45, 18, 239, 91, 112, 110, 45, 200, 173, 43, 4, 184, 215, 217, 217, 233, 118, 187, 235, 235, 235, 155, 155, 155, 197, 123, 37, 74, 91, 20, 192, 55, 166, 101, 73, 73, 9, 59, 42, 22, 170, 184, 189, 51, 35, 129, 78, 191, 223, 255, 224, 193, 131, 171, 87, 175, 54, 54, 54, 50, 111, 127, 69, 241, 222, 19, 139, 1, 33, 183, 97, 195, 6, 142, 242, 43, 250, 104, 178, 116, 12, 20, 10, 32, 137, 76, 251, 238, 221, 59, 241, 238, 26, 150, 70, 244, 238, 154, 195, 225, 152, 53, 107, 150, 120, 119, 109, 226, 196, 137, 105, 105, 105, 212, 43, 93, 163, 67, 12, 20, 170, 7, 152, 19, 33, 21, 87, 91, 91, 91, 201, 186, 30, 143, 199, 235, 245, 250, 124, 190, 79, 159, 62, 241, 44, 154, 216, 40, 19, 84, 108, 30, 156, 78, 39, 11, 128, 203, 229, 154, 62, 125, 122, 65, 65, 1, 34, 145, 10, 44, 164, 19, 3, 68, 171, 80, 51, 127, 56, 23, 252, 56, 10, 3, 113, 79, 24, 40, 32, 186, 209, 42, 128, 141, 0, 187, 56, 138, 38, 53, 232, 32, 47, 177, 12, 235, 10, 35, 125, 60, 157, 185, 68, 41, 152, 134, 184, 36, 26, 157, 214, 115, 148, 120, 170, 121, 210, 161, 122, 26, 179, 167, 213, 184, 67, 88, 88, 87, 40, 16, 234, 241, 6, 202, 53, 77, 230, 123, 90, 67, 180, 10, 67, 193, 96, 224, 205, 123, 18, 165, 123, 2, 131, 165, 48, 113, 48, 164, 208, 254, 24, 82, 104, 127, 12, 41, 180, 63, 254, 117, 133, 73, 73, 255, 3, 221, 44, 205, 59, 15, 27, 243, 167, 0, 0, 0, 0, 73, 69, 78, 68, 174, 66, 96, 130 };
        private readonly byte[] expectedOutputContent = { 137, 80, 78, 71, 13, 10, 26, 10, 0, 0, 0, 13, 73, 72, 68, 82, 0, 0, 0, 75, 0, 0, 0, 85, 8, 2, 0, 0, 0, 142, 240, 142, 86, 0, 0, 0, 1, 115, 82, 71, 66, 0, 174, 206, 28, 233, 0, 0, 0, 4, 103, 65, 77, 65, 0, 0, 177, 143, 11, 252, 97, 5, 0, 0, 0, 9, 112, 72, 89, 115, 0, 0, 14, 195, 0, 0, 14, 195, 1, 199, 111, 168, 100, 0, 0, 8, 46, 73, 68, 65, 84, 120, 94, 237, 155, 217, 79, 19, 93, 24, 198, 65, 16, 4, 197, 130, 11, 246, 70, 148, 68, 75, 226, 194, 226, 134, 91, 226, 74, 140, 127, 128, 81, 19, 99, 226, 18, 183, 27, 151, 196, 68, 69, 208, 72, 0, 47, 52, 94, 34, 137, 75, 226, 26, 252, 11, 212, 104, 53, 18, 227, 6, 26, 35, 23, 164, 26, 209, 122, 83, 5, 215, 162, 72, 241, 195, 239, 23, 206, 120, 24, 166, 211, 233, 116, 90, 108, 199, 240, 92, 12, 115, 150, 153, 121, 158, 243, 156, 247, 61, 167, 165, 147, 252, 227, 199, 143, 164, 127, 26, 195, 148, 191, 255, 46, 134, 20, 218, 31, 214, 21, 38, 39, 39, 43, 103, 73, 73, 191, 127, 255, 86, 206, 66, 128, 206, 97, 251, 12, 18, 98, 227, 161, 90, 173, 46, 144, 167, 233, 163, 43, 216, 248, 62, 214, 198, 40, 150, 185, 84, 99, 84, 111, 111, 239, 127, 125, 16, 149, 20, 101, 43, 61, 5, 134, 245, 33, 37, 37, 133, 163, 104, 146, 160, 213, 154, 36, 13, 98, 160, 16, 30, 130, 46, 39, 224, 87, 31, 190, 126, 253, 218, 218, 218, 218, 210, 210, 226, 241, 120, 222, 190, 125, 235, 243, 249, 62, 127, 254, 204, 179, 122, 122, 122, 134, 15, 31, 158, 153, 153, 153, 147, 147, 227, 116, 58, 39, 77, 154, 228, 114, 185, 102, 204, 152, 81, 80, 80, 144, 157, 157, 157, 218, 7, 110, 37, 238, 44, 238, 41, 206, 45, 35, 102, 30, 226, 85, 32, 16, 240, 122, 189, 110, 183, 251, 206, 157, 59, 79, 159, 62, 253, 242, 229, 139, 244, 80, 109, 160, 0, 236, 241, 141, 35, 6, 162, 106, 244, 232, 209, 37, 37, 37, 203, 251, 144, 151, 151, 151, 158, 158, 78, 189, 210, 53, 58, 196, 64, 33, 142, 249, 253, 254, 135, 15, 31, 94, 185, 114, 165, 177, 177, 17, 247, 168, 65, 152, 210, 108, 26, 66, 170, 195, 225, 88, 188, 120, 241, 250, 245, 235, 23, 46, 92, 152, 149, 149, 133, 225, 98, 104, 44, 251, 25, 149, 66, 156, 65, 219, 173, 91, 183, 234, 235, 235, 159, 61, 123, 246, 243, 231, 79, 147, 194, 4, 221, 80, 164, 145, 58, 98, 196, 136, 162, 162, 162, 29, 59, 118, 148, 149, 149, 161, 51, 56, 74, 205, 195, 186, 66, 244, 52, 53, 53, 157, 56, 113, 226, 254, 253, 251, 93, 93, 93, 168, 53, 51, 204, 193, 125, 100, 141, 166, 9, 85, 25, 25, 25, 56, 185, 127, 255, 254, 217, 179, 103, 19, 186, 97, 111, 174, 11, 43, 10, 17, 243, 225, 195, 7, 124, 59, 123, 246, 44, 249, 3, 223, 204, 104, 179, 6, 252, 36, 3, 109, 218, 180, 105, 215, 174, 93, 185, 185, 185, 193, 102, 242, 92, 158, 174, 20, 244, 16, 177, 66, 146, 225, 243, 231, 207, 43, 43, 43, 9, 60, 108, 84, 106, 7, 1, 234, 81, 99, 210, 150, 150, 150, 86, 85, 85, 49, 117, 137, 76, 81, 105, 18, 145, 41, 68, 210, 245, 235, 215, 43, 42, 42, 222, 188, 121, 99, 33, 151, 68, 3, 204, 100, 105, 65, 228, 234, 213, 171, 17, 172, 212, 154, 64, 4, 17, 76, 176, 93, 186, 116, 105, 247, 238, 221, 175, 95, 191, 14, 37, 207, 120, 194, 68, 3, 158, 216, 214, 214, 182, 103, 207, 158, 139, 23, 47, 74, 87, 204, 132, 134, 89, 15, 233, 118, 254, 252, 249, 234, 234, 106, 86, 57, 81, 51, 120, 177, 103, 12, 150, 147, 242, 242, 242, 45, 91, 182, 224, 164, 153, 1, 13, 239, 33, 50, 152, 156, 172, 117, 53, 53, 53, 200, 147, 55, 141, 139, 60, 192, 122, 91, 91, 91, 123, 249, 242, 229, 238, 238, 110, 165, 202, 16, 225, 21, 178, 124, 223, 184, 113, 3, 247, 72, 155, 20, 227, 37, 12, 200, 193, 133, 9, 124, 200, 8, 164, 61, 81, 99, 128, 240, 179, 148, 165, 124, 227, 198, 141, 196, 94, 28, 181, 5, 3, 181, 249, 249, 249, 23, 46, 92, 40, 46, 46, 54, 222, 15, 132, 241, 176, 189, 189, 253, 192, 129, 3, 100, 206, 132, 146, 7, 224, 195, 134, 254, 224, 193, 131, 31, 63, 126, 52, 230, 166, 175, 80, 92, 67, 248, 213, 213, 213, 61, 121, 242, 228, 47, 47, 12, 38, 1, 43, 184, 157, 62, 125, 218, 56, 32, 245, 21, 50, 7, 216, 184, 48, 63, 207, 157, 59, 55, 168, 203, 122, 148, 128, 27, 251, 42, 120, 194, 86, 169, 250, 3, 105, 108, 191, 66, 170, 212, 201, 183, 179, 179, 243, 212, 169, 83, 204, 1, 165, 156, 144, 128, 48, 12, 225, 9, 91, 165, 234, 15, 164, 150, 1, 30, 34, 82, 72, 103, 2, 240, 25, 239, 238, 221, 187, 137, 57, 63, 37, 96, 11, 67, 120, 26, 80, 237, 87, 40, 68, 139, 227, 247, 239, 223, 217, 88, 27, 164, 89, 181, 219, 113, 7, 60, 97, 11, 103, 81, 20, 38, 73, 232, 196, 33, 131, 193, 174, 186, 185, 185, 57, 120, 114, 75, 104, 238, 18, 95, 192, 19, 182, 143, 30, 61, 18, 54, 170, 173, 2, 58, 10, 3, 129, 192, 181, 107, 215, 216, 133, 42, 229, 4, 131, 238, 244, 193, 198, 134, 134, 6, 152, 43, 101, 149, 7, 90, 133, 52, 188, 127, 255, 158, 143, 237, 108, 101, 148, 170, 4, 131, 238, 244, 129, 237, 237, 219, 183, 249, 212, 170, 148, 85, 208, 42, 20, 129, 251, 237, 219, 55, 165, 108, 31, 176, 95, 37, 59, 6, 27, 163, 85, 72, 15, 183, 219, 109, 102, 191, 151, 104, 128, 51, 204, 225, 31, 38, 14, 153, 208, 50, 100, 237, 5, 56, 63, 126, 252, 24, 254, 98, 26, 235, 199, 33, 73, 233, 229, 203, 151, 9, 190, 202, 27, 160, 163, 163, 227, 213, 171, 87, 114, 9, 16, 34, 181, 10, 91, 90, 90, 236, 104, 160, 0, 204, 225, 47, 21, 138, 137, 170, 85, 232, 241, 120, 100, 15, 219, 65, 242, 87, 231, 91, 173, 66, 175, 215, 107, 95, 15, 5, 127, 142, 234, 79, 140, 90, 133, 62, 159, 79, 119, 73, 181, 5, 176, 14, 254, 70, 30, 146, 106, 253, 126, 191, 186, 217, 94, 128, 57, 43, 185, 88, 234, 164, 10, 173, 66, 54, 62, 246, 85, 8, 224, 47, 162, 76, 127, 61, 68, 155, 125, 131, 80, 0, 254, 26, 135, 6, 40, 68, 119, 74, 74, 138, 125, 227, 16, 4, 243, 31, 160, 144, 230, 244, 244, 116, 91, 207, 82, 248, 167, 166, 166, 42, 133, 62, 12, 80, 152, 150, 150, 150, 149, 149, 101, 95, 15, 97, 14, 127, 35, 133, 244, 152, 48, 97, 130, 173, 21, 58, 157, 78, 177, 24, 234, 231, 82, 218, 242, 242, 242, 212, 203, 165, 189, 212, 170, 249, 75, 230, 90, 133, 46, 151, 75, 221, 195, 94, 49, 9, 243, 169, 83, 167, 10, 254, 18, 90, 133, 51, 103, 206, 36, 223, 112, 110, 199, 124, 67, 4, 22, 22, 22, 134, 81, 56, 101, 202, 148, 113, 227, 198, 41, 101, 91, 129, 73, 7, 115, 248, 27, 41, 4, 153, 153, 153, 243, 230, 205, 19, 54, 218, 11, 112, 158, 59, 119, 110, 70, 70, 134, 82, 254, 3, 173, 66, 140, 94, 190, 124, 121, 164, 255, 43, 79, 4, 192, 124, 197, 138, 21, 28, 69, 124, 233, 103, 26, 64, 143, 101, 203, 150, 57, 28, 14, 165, 108, 31, 100, 103, 103, 195, 28, 254, 50, 71, 138, 147, 126, 133, 50, 181, 228, 230, 230, 138, 193, 16, 69, 91, 128, 73, 7, 103, 152, 43, 229, 62, 8, 69, 253, 10, 165, 173, 236, 108, 214, 174, 93, 75, 64, 138, 162, 45, 64, 248, 173, 89, 179, 70, 19, 92, 90, 133, 18, 132, 108, 105, 105, 233, 156, 57, 115, 52, 73, 41, 97, 1, 79, 216, 206, 159, 63, 95, 147, 32, 181, 179, 84, 122, 136, 244, 145, 35, 71, 110, 219, 182, 141, 163, 168, 73, 88, 8, 206, 240, 220, 190, 125, 123, 40, 182, 58, 113, 200, 101, 12, 198, 210, 165, 75, 151, 44, 89, 146, 152, 203, 134, 218, 12, 12, 36, 193, 192, 86, 151, 42, 61, 181, 243, 80, 94, 60, 106, 212, 168, 125, 251, 246, 169, 87, 127, 217, 20, 119, 72, 51, 192, 248, 241, 227, 247, 238, 221, 27, 108, 32, 125, 4, 180, 10, 169, 18, 39, 140, 77, 113, 113, 241, 214, 173, 91, 229, 79, 172, 100, 83, 226, 0, 110, 48, 44, 42, 42, 10, 78, 25, 248, 33, 44, 209, 54, 0, 233, 21, 215, 51, 191, 131, 35, 56, 65, 0, 43, 184, 237, 220, 185, 147, 79, 189, 74, 149, 10, 253, 86, 137, 63, 106, 168, 189, 26, 59, 118, 236, 241, 227, 199, 243, 243, 243, 165, 236, 4, 1, 124, 96, 85, 91, 91, 155, 147, 147, 163, 203, 77, 86, 234, 40, 84, 131, 126, 211, 166, 77, 171, 169, 169, 209, 44, 166, 113, 7, 124, 170, 171, 171, 225, 22, 118, 232, 195, 40, 4, 108, 110, 86, 174, 92, 89, 89, 89, 57, 102, 204, 24, 165, 234, 239, 34, 88, 3, 76, 42, 42, 42, 202, 202, 202, 228, 198, 203, 32, 71, 132, 87, 8, 8, 72, 118, 57, 229, 229, 229, 113, 17, 169, 97, 207, 254, 243, 208, 161, 67, 235, 214, 173, 99, 31, 35, 197, 27, 56, 25, 193, 47, 104, 187, 186, 186, 26, 26, 26, 142, 30, 61, 218, 222, 222, 174, 59, 102, 60, 198, 96, 44, 163, 7, 247, 103, 109, 56, 114, 228, 136, 144, 167, 212, 134, 131, 89, 133, 130, 122, 32, 16, 184, 121, 243, 38, 102, 182, 181, 181, 253, 229, 239, 142, 153, 144, 147, 39, 79, 174, 170, 170, 90, 181, 106, 149, 92, 192, 204, 32, 178, 95, 65, 131, 158, 158, 158, 23, 47, 94, 28, 62, 124, 120, 176, 127, 231, 173, 6, 146, 22, 44, 88, 112, 236, 216, 177, 194, 194, 66, 177, 189, 102, 196, 213, 51, 83, 83, 84, 35, 98, 133, 160, 183, 183, 183, 163, 163, 163, 174, 174, 238, 204, 153, 51, 226, 197, 24, 165, 97, 16, 192, 162, 199, 122, 176, 121, 243, 102, 214, 61, 242, 167, 65, 188, 133, 130, 21, 133, 2, 221, 221, 221, 77, 77, 77, 39, 79, 158, 188, 119, 239, 30, 102, 34, 91, 105, 136, 17, 216, 166, 16, 108, 139, 22, 45, 18, 239, 91, 112, 110, 45, 200, 173, 43, 4, 184, 215, 217, 217, 233, 118, 187, 235, 235, 235, 155, 155, 155, 197, 123, 37, 74, 91, 20, 192, 55, 166, 101, 73, 73, 9, 59, 42, 22, 170, 184, 189, 51, 35, 129, 78, 191, 223, 255, 224, 193, 131, 171, 87, 175, 54, 54, 54, 50, 111, 127, 69, 241, 222, 19, 139, 1, 33, 183, 97, 195, 6, 142, 242, 43, 250, 104, 178, 116, 12, 20, 10, 32, 137, 76, 251, 238, 221, 59, 241, 238, 26, 150, 70, 244, 238, 154, 195, 225, 152, 53, 107, 150, 120, 119, 109, 226, 196, 137, 105, 105, 105, 212, 43, 93, 163, 67, 12, 20, 170, 7, 152, 19, 33, 21, 87, 91, 91, 91, 201, 186, 30, 143, 199, 235, 245, 250, 124, 190, 79, 159, 62, 241, 44, 154, 216, 40, 19, 84, 108, 30, 156, 78, 39, 11, 128, 203, 229, 154, 62, 125, 122, 65, 65, 1, 34, 145, 10, 44, 164, 19, 3, 68, 171, 80, 51, 127, 56, 23, 252, 56, 10, 3, 113, 79, 24, 40, 32, 186, 209, 42, 128, 141, 0, 187, 56, 138, 38, 53, 232, 32, 47, 177, 12, 235, 10, 35, 125, 60, 157, 185, 68, 41, 152, 134, 184, 36, 26, 157, 214, 115, 148, 120, 170, 121, 210, 161, 122, 26, 179, 167, 213, 184, 67, 88, 88, 87, 40, 16, 234, 241, 6, 202, 53, 77, 230, 123, 90, 67, 180, 10, 67, 193, 96, 224, 205, 123, 18, 165, 123, 2, 131, 165, 48, 113, 48, 164, 208, 254, 24, 82, 104, 127, 12, 41, 180, 63, 254, 117, 133, 73, 73, 255, 3, 221, 44, 205, 59, 15, 27, 243, 167, 0, 0, 0, 0, 73, 69, 78, 68, 174, 66, 96, 130 };
        
        [SetUp]
        public void Setup()
        {
            sourceFile = CreateFile(nameof(sourceFile) + ".png", sourceContent);
            expectedOutput = CreateFile(nameof(expectedOutput) + ".png", expectedOutputContent);
        }
        
        [Test]
        public void CopyBinaryFileTest1()
        {
            string actualOutput = @"output.png";

            CopyBinaryFile.CopyFile(sourceFile, actualOutput);

            Assert.IsTrue(AreFileContentsEqual(expectedOutput, actualOutput), 
                $"{nameof(CopyBinaryFile.CopyFile)} output is incorrect!");
        }

        private static string CreateFile(string name, byte[] content)
        {
            File.WriteAllBytes(name, content);
            return name;
        }

        public static bool AreFileContentsEqual(string pathOne, string pathTwo) =>
            File.ReadAllBytes(pathOne).SequenceEqual(File.ReadAllBytes(pathTwo));
    }
}
