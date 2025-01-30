#ifndef TREENODE_H
#define TREENODE_H

#include <vector>
#include <queue>

struct TreeNode {
    int val;
    TreeNode* left;
    TreeNode* right;
    TreeNode(int x) : val(x), left(nullptr), right(nullptr) {}
};

// Helper functions for testing
TreeNode* createBinaryTree(const std::vector<int>& values);
std::vector<int> binaryTreeToVector(TreeNode* root);
void deleteBinaryTree(TreeNode* root);
std::vector<int> collectLeafNodes(TreeNode* head, std::vector<int>& endLeaves);

// Actual Methods
// https://leetcode.com/problems/maximum-depth-of-binary-tree
int maxDepth(TreeNode* root);

// https://leetcode.com/problems/leaf-similar-trees
bool leafSimilar(TreeNode* root1, TreeNode* root2);

#endif // TREENODE_H
